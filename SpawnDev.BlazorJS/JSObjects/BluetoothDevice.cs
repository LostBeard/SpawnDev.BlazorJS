using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class BluetoothDevice : EventTarget
    {
        public BluetoothDevice(IJSInProcessObjectReference _ref) : base(_ref) { }

    }
}
