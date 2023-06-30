namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The UserActivation interface allows querying information about a window's user activation state. 
    /// https://developer.mozilla.org/en-US/docs/Web/API/UserActivation
    /// https://developer.mozilla.org/en-US/docs/Web/Security/User_activation
    /// </summary>
    public class UserActivation
    {
        public bool HasBeenActive { get; set; }
        public bool IsActive { get; set; }
    }
}
