namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// If used for CredentialsContainer.Get()<br/>
    /// an OtpCredential will be returned
    /// https://developer.mozilla.org/en-US/docs/Web/API/CredentialsContainer/get#options
    /// </summary>
    public class CredentialGetOtpOptions : CredentialGetOptions
    {
        /// <summary>
        /// An object containing transport type hints. Causes the get() call to initiate a request for the retrieval of an OTP. See the WebOTP API section below for more details.
        /// </summary>
        public CredentialGetOtp Otp { get; set; }
    }
}
