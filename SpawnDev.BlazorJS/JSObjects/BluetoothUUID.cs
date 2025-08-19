namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The BluetoothUUID interface of the Web Bluetooth API provides a way to look up Universally Unique Identifier (UUID) values by name in the registry maintained by the Bluetooth SIG.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/BluetoothUUID
    /// </summary>
    public static class BluetoothUUID
    {
        static BlazorJSRuntime JS => BlazorJSRuntime.JS;
        /// <summary>
        /// Returns the 128-bit UUID when passed the 16- or 32-bit UUID alias.
        /// </summary>
        /// <param name="alias">A string containing a 16-bit or 32-bit UUID alias.</param>
        /// <returns>A 128-bit UUID.</returns>
        public static string CanonicalUUID(uint alias) => JS.Call<String>("BluetoothUUID.canonicalUUID", alias);
        /// <summary>
        /// Returns the 128-bit UUID representing a registered characteristic when passed a name or the 16- or 32-bit UUID alias.
        /// </summary>
        /// <param name="name">A string containing the name of the characteristic.</param>
        /// <returns>A 128-bit UUID.</returns>
        public static string GetCharacteristic(string name) => JS.Call<String>("BluetoothUUID.getCharacteristic", name);
        /// <summary>
        /// Returns a UUID representing a registered descriptor when passed a name or the 16- or 32-bit UUID alias.
        /// </summary>
        /// <param name="name">A string containing the name of the descriptor.</param>
        /// <returns>A 128-bit UUID.</returns>
        public static string GetDescriptor(string name) => JS.Call<String>("BluetoothUUID.getDescriptor", name);
        /// <summary>
        /// Returns a UUID representing a registered service when passed a name or the 16- or 32-bit UUID alias.
        /// </summary>
        /// <param name="name">A string containing the name of the service.</param>
        /// <returns>A 128-bit UUID.</returns>
        public static string GetService(string name) => JS.Call<String>("BluetoothUUID.getService", name);
    }
}
