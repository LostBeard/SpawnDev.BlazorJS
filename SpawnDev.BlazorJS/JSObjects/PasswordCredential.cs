using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The PasswordCredential interface of the Credential Management API provides information about a username/password pair.
    /// </summary>
    public class PasswordCredential : Credential
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public PasswordCredential(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The PasswordCredential() constructor creates a new PasswordCredential object.
        /// </summary>
        /// <param name="data"></param>
        public PasswordCredential(PasswordCredentialData data) : base(JS.New("PasswordCredential", data)) { }
        /// <summary>
        /// The PasswordCredential() constructor creates a new PasswordCredential object.
        /// </summary>
        /// <param name="data"></param>
        public PasswordCredential(HTMLFormElement data) : base(JS.New("PasswordCredential", data)) { }
        /// <summary>
        /// Returns a string containing a URL of an image for a user's avatar.
        /// </summary>
        public string? IconURL => JSRef!.Get<string?>("iconURL");
        /// <summary>
        /// Returns a string containing the name used to display the user's name when sign-in or sign-up is in progress.
        /// </summary>
        public string? Name => JSRef!.Get<string?>("name");
        /// <summary>
        /// Returns a string containing the user's password.
        /// </summary>
        public string? Password => JSRef!.Get<string?>("password");

    }
}
