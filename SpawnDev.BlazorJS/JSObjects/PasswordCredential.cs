using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class PasswordCredential : Credential
    {
        public PasswordCredential(IJSInProcessObjectReference _ref) : base(_ref) { }
        public PasswordCredential(PasswordCredentialData data) : base(JS.New("PasswordCredential", data)) { }
        public PasswordCredential(HTMLFormElement data) : base(JS.New("PasswordCredential", data)) { }
        public string? IconURL => JSRef!.Get<string?>("iconURL");
        public string? Name => JSRef!.Get<string?>("name");
        public string? Password => JSRef!.Get<string?>("password");

    }
}
