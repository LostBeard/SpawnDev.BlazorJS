using SpawnDev.Blazor.UnitTesting;
using SpawnDev.BlazorJS.JSObjects;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace SpawnDev.BlazorJS.Demo.UnitTests
{
    /// <summary>
    /// The WebAuthn JSON converters: PublicKeyCredential.ParseCreationOptionsFromJSON / ParseRequestOptionsFromJSON turn a
    /// relying party server's base64url JSON into the browser's options objects, CredentialsContainer.Create / Get take
    /// them, and PublicKeyCredential.ToJSONString gives the JSON to send back. The create / get case needs an
    /// authenticator: PlaywrightTestRunner adds a CDP virtual authenticator (ctap2, internal, resident key, user
    /// verification) to its page. Parallel of SpawnDev.SpawnJS 3.0.9 (WebAuthnTests).
    /// </summary>
    public class WebAuthnTests(BlazorJSRuntime JS)
    {
        static string B64U(byte[] bytes) => Convert.ToBase64String(bytes).TrimEnd('=').Replace('+', '-').Replace('/', '_');
        static byte[] FromB64U(string s)
        {
            s = s.Replace('-', '+').Replace('_', '/');
            return Convert.FromBase64String(s + new string('=', (4 - s.Length % 4) % 4));
        }
        static void Same(byte[] got, byte[] expected, string what)
        {
            if (!got.SequenceEqual(expected)) throw new Exception($"{what}: {got.Length} bytes [{B64U(got)}], expected {expected.Length} [{B64U(expected)}]");
        }
        static readonly byte[] Challenge = Enumerable.Range(1, 32).Select(i => (byte)i).ToArray();
        static readonly byte[] UserId = Encoding.UTF8.GetBytes("blazorjs-user-1");
        static string CreationJson(string rpId, byte[] challenge, byte[] userId) => new JsonObject
        {
            ["rp"] = new JsonObject { ["id"] = rpId, ["name"] = "BlazorJS test" },
            ["user"] = new JsonObject { ["id"] = B64U(userId), ["name"] = "test@spawndev.test", ["displayName"] = "BlazorJS Test" },
            ["challenge"] = B64U(challenge),
            ["pubKeyCredParams"] = new JsonArray(
                new JsonObject { ["type"] = "public-key", ["alg"] = -7 },
                new JsonObject { ["type"] = "public-key", ["alg"] = -257 }),
            ["timeout"] = 60000,
            ["authenticatorSelection"] = new JsonObject { ["residentKey"] = "preferred", ["userVerification"] = "preferred" },
            ["attestation"] = "none",
        }.ToJsonString();
        static string RequestJson(string rpId, byte[] challenge, string credentialId) => new JsonObject
        {
            ["challenge"] = B64U(challenge),
            ["rpId"] = rpId,
            ["allowCredentials"] = new JsonArray(new JsonObject { ["type"] = "public-key", ["id"] = credentialId }),
            ["userVerification"] = "preferred",
            ["timeout"] = 60000,
        }.ToJsonString();
        static (string Type, string Challenge, string Origin) ClientData(JsonElement response)
        {
            var clientData = JsonDocument.Parse(FromB64U(response.GetProperty("clientDataJSON").GetString()!)).RootElement;
            return (clientData.GetProperty("type").GetString()!, clientData.GetProperty("challenge").GetString()!, clientData.GetProperty("origin").GetString()!);
        }

        [TestMethod]
        public async Task IsJSONSupported()
        {
            if (!PublicKeyCredential.IsJSONSupported) throw new Exception("PublicKeyCredential JSON converters reported missing");
            await Task.CompletedTask;
        }

        [TestMethod]
        public async Task ParseCreationOptionsFromJSONFillsTheArrayBuffers()
        {
            var rpId = JS.Get<string>("location.hostname");
            using var options = PublicKeyCredential.ParseCreationOptionsFromJSON(CreationJson(rpId, Challenge, UserId));
            using var challengeBuffer = options.Challenge;
            Same(challengeBuffer.ReadBytes(), Challenge, "challenge");
            using var userIdBuffer = options.JSRef!.Get<ArrayBuffer>("user.id");
            Same(userIdBuffer.ReadBytes(), UserId, "user.id");
            var seenRp = options.JSRef!.Get<string>("rp.id");
            if (seenRp != rpId) throw new Exception($"rp.id is '{seenRp}', expected '{rpId}'");
            await Task.CompletedTask;
        }

        [TestMethod]
        public async Task ParseRequestOptionsFromJSONFillsTheArrayBuffers()
        {
            var rpId = JS.Get<string>("location.hostname");
            var credentialId = Enumerable.Range(100, 20).Select(i => (byte)i).ToArray();
            using var options = PublicKeyCredential.ParseRequestOptionsFromJSON(RequestJson(rpId, Challenge, B64U(credentialId)));
            using var challengeBuffer = options.Challenge;
            Same(challengeBuffer.ReadBytes(), Challenge, "challenge");
            using var idBuffer = options.JSRef!.Get<ArrayBuffer>("allowCredentials.0.id");
            Same(idBuffer.ReadBytes(), credentialId, "allowCredentials[0].id");
            await Task.CompletedTask;
        }

        [TestMethod]
        public async Task CreateAndGetThroughJSON()
        {
            // A real ceremony needs an authenticator: the test runner's virtual one (Chromium), or a person
            if (JS.IsUndefined("virtualAuthenticator"))
                throw new UnsupportedTestException("No virtual authenticator (the Playwright runner adds one on Chromium). Run manually with a passkey device.");
            var rpId = JS.Get<string>("location.hostname");
            var origin = JS.Get<string>("location.origin");
            using var credentials = CredentialsContainer.GetDefaultCredentialsContainer();

            using var creationOptions = PublicKeyCredential.ParseCreationOptionsFromJSON(CreationJson(rpId, Challenge, UserId));
            using var created = await credentials.Create(creationOptions);
            var registration = JsonDocument.Parse(created.ToJSONString()).RootElement;
            var id = registration.GetProperty("id").GetString()!;
            if (registration.GetProperty("rawId").GetString() != id) throw new Exception("rawId differs from id");
            if (registration.GetProperty("type").GetString() != "public-key") throw new Exception($"type is {registration.GetProperty("type")}");
            using var rawId = created.RawId;
            Same(rawId.ReadBytes(), FromB64U(id), "RawId vs the JSON id");
            var (regType, regChallenge, regOrigin) = ClientData(registration.GetProperty("response"));
            if (regType != "webauthn.create") throw new Exception($"clientData.type is {regType}");
            if (regChallenge != B64U(Challenge)) throw new Exception($"clientData.challenge is {regChallenge}");
            if (regOrigin != origin) throw new Exception($"clientData.origin is {regOrigin}, expected {origin}");

            var challenge2 = Enumerable.Range(200, 32).Select(i => (byte)i).ToArray();
            using var requestOptions = PublicKeyCredential.ParseRequestOptionsFromJSON(RequestJson(rpId, challenge2, id));
            using var asserted = await credentials.Get(requestOptions);
            if (asserted == null) throw new Exception("get() resolved null");
            var authentication = JsonDocument.Parse(asserted.ToJSONString()).RootElement;
            if (authentication.GetProperty("id").GetString() != id) throw new Exception($"asserted id {authentication.GetProperty("id")}, expected {id}");
            var authResponse = authentication.GetProperty("response");
            var (authType, authChallenge, authOrigin) = ClientData(authResponse);
            if (authType != "webauthn.get") throw new Exception($"clientData.type is {authType}");
            if (authChallenge != B64U(challenge2)) throw new Exception($"clientData.challenge is {authChallenge}");
            if (authOrigin != origin) throw new Exception($"clientData.origin is {authOrigin}, expected {origin}");
            if (FromB64U(authResponse.GetProperty("signature").GetString()!).Length == 0) throw new Exception("empty signature");
        }
    }
}
