# CredentialCreatePublicKey

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/CredentialCreatePublicKey.cs`  
**MDN Reference:** [CredentialCreatePublicKey on MDN](https://developer.mozilla.org/en-US/docs/Web/API/CredentialsContainer/create#publickey_object_structure)

> Options for CredentialsContainer.Create() https://developer.mozilla.org/en-US/docs/Web/API/CredentialsContainer/create#publickey_object_structure

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `CredentialCreatePublicKey` | `class` | get | Options for CredentialsContainer.Create() https://developer.mozilla.org/en-US/docs/Web/API/CredentialsContainer/create#publickey_object_structure |
| `AttestationFormats` | `List<string>?` | get |  |
| `AuthenticatorSelection` | `AuthenticatorSelection?` | get |  |
| `Challenge` | `Union<ArrayBuffer, Uint8Array, DataView, byte[]>` | get | An ArrayBuffer, TypedArray, or DataView provided by the relying party's server and used as a cryptographic challenge. This value will be signed by the authenticator and the signature will be sent back as part of AuthenticatorAttestationResponse.attestationObject. 32 byte challenge. Must be randomly generated on the server. |
| `ExcludeCredentials` | `IEnumerable<CredentialCreatePublicKeyExclude>?` | get |  |
| `Extensions` | `object?` | get |  |
| `PubKeyCredParams` | `List<PublicKeyCredentialParameter>` | get | An Array of objects which specify the key types and signature algorithms the Relying Party supports, ordered from most preferred to least preferred. The client and authenticator will make a best-effort to create a credential of the most preferred type possible. |
| `Rp` | `RelyingParty` | get | An object describing the relying party that requested the credential creation. It can contain the following properties: |
| `Timeout` | `double?` | get/set |  |
| `User` | `CredentialUser` | get | An object describing the user account for which the credential is generated |
| `Hints` | `List<string>?` | get |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<CredentialCreatePublicKey>(...)` or constructor `new CredentialCreatePublicKey(...)`

### Creating a password credential

```js
const credInit = {
  id: "serpent1234", // "username" in a typical username/password pair
  name: "Serpentina", // display name for credential
  origin: "https://example.org",
  password: "the last visible dog",
};

const makeCredential = document.querySelector("#make-credential");

makeCredential.addEventListener("click", async () => {
  const cred = await navigator.credentials.create({
    password: credInit,
  });
  console.log(cred.name);
  // Serpentina
  console.log(cred.id);
  // serpent1234
  console.log(cred.password);
  // the last visible dog
});
```

### Creating a federated credential

```js
const credInit = {
  id: "1234",
  name: "Serpentina",
  origin: "https://example.org",
  protocol: "openidconnect",
  provider: "https://provider.example.org",
};

const makeCredential = document.querySelector("#make-credential");

makeCredential.addEventListener("click", async () => {
  const cred = await navigator.credentials.create({
    federated: credInit,
  });
  console.log(cred.name);
  console.log(cred.provider);
});
```

### Creating a public key credential

```js
const publicKey = {
  challenge: challengeFromServer,
  rp: { id: "acme.com", name: "ACME Corporation" },
  user: {
    id: new Uint8Array([79, 252, 83, 72, 214, 7, 89, 26]),
    name: "jamiedoe",
    displayName: "Jamie Doe",
  },
  pubKeyCredParams: [{ type: "public-key", alg: -7 }],
};

const publicKeyCredential = await navigator.credentials.create({ publicKey });
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/CredentialsContainer/create)*

## Examples

### Creating a password credential

This example creates a password credential from a {{domxref("PasswordCredentialInit")}} object.

```js
const credInit = {
  id: "serpent1234", // "username" in a typical username/password pair
  name: "Serpentina", // display name for credential
  origin: "https://example.org",
  password: "the last visible dog",
};

const makeCredential = document.querySelector("#make-credential");

makeCredential.addEventListener("click", async () => {
  const cred = await navigator.credentials.create({
    password: credInit,
  });
  console.log(cred.name);
  // Serpentina
  console.log(cred.id);
  // serpent1234
  console.log(cred.password);
  // the last visible dog
});
```

### Creating a federated credential

This example creates a federated credential from a {{domxref("FederatedCredentialInit")}} object.

```js
const credInit = {
  id: "1234",
  name: "Serpentina",
  origin: "https://example.org",
  protocol: "openidconnect",
  provider: "https://provider.example.org",
};

const makeCredential = document.querySelector("#make-credential");

makeCredential.addEventListener("click", async () => {
  const cred = await navigator.credentials.create({
    federated: credInit,
  });
  console.log(cred.name);
  console.log(cred.provider);
});
```

### Creating a public key credential

This example creates a public key credential from a {{domxref("PublicKeyCredentialCreationOptions")}} object.

```js
const publicKey = {
  challenge: challengeFromServer,
  rp: { id: "acme.com", name: "ACME Corporation" },
  user: {
    id: new Uint8Array([79, 252, 83, 72, 214, 7, 89, 26]),
    name: "jamiedoe",
    displayName: "Jamie Doe",
  },
  pubKeyCredParams: [{ type: "public-key", alg: -7 }],
};

const publicKeyCredential = await navigator.credentials.create({ publicKey });
```

The `create()` call, if successful, returns a promise that resolves with a {{domxref("PublicKeyCredential")}} object instance, representing a public key credential that can later be used to authenticate a user via a WebAuthn {{domxref("CredentialsContainer.get()", "get()")}} call. Its {{domxref("PublicKeyCredential.response")}} property contains an {{domxref("AuthenticatorAttestationResponse")}} object providing access to several useful pieces of information including the authenticator data, public key, transport mechanisms, and more.

**JavaScript (MDN):**

```js
navigator.credentials.create({ publicKey }).then((publicKeyCredential) => {
  const response = publicKeyCredential.response;

  // Access attestationObject ArrayBuffer
  const attestationObj = response.attestationObject;

  // Access client JSON
  const clientJSON = response.clientDataJSON;

  // Return authenticator data ArrayBuffer
  const authenticatorData = response.getAuthenticatorData();

  // Return public key ArrayBuffer
  const pk = response.getPublicKey();

  // Return public key algorithm identifier
  const pkAlgo = response.getPublicKeyAlgorithm();

  // Return permissible transports array
  const transports = response.getTransports();
});
```

**C# (SpawnDev.BlazorJS):**

```csharp
// Requires: builder.Services.AddBlazorJSRuntime();
// Inject BlazorJSRuntime in your component or service:
// [Inject] BlazorJSRuntime JS { get; set; }

navigator.credentials.create({ publicKey }); // then: use await instead;
var response = publicKeyCredential.response;

// Access attestationObject ArrayBuffer
var attestationObj = response.attestationObject;

// Access client JSON
var clientJSON = response.clientDataJSON;

// Return authenticator data ArrayBuffer
var authenticatorData = response.getAuthenticatorData();

// Return public key ArrayBuffer
var pk = response.getPublicKey();

// Return public key algorithm identifier
var pkAlgo = response.getPublicKeyAlgorithm();

// Return permissible transports array
var transports = response.getTransports();
});
```

