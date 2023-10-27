using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The MIDIOutput interface of the Web MIDI API provides methods to add messages to the queue of an output device, and to clear the queue of messages.
    /// </summary>
    public class MIDIOutput : MIDIPort
    {
        #region Constructors
        public MIDIOutput(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        /// <summary>
        /// Queues a message to be sent to the MIDI port.
        /// </summary>
        public void Send(byte[] data) => JSRef.CallVoid("send", data);
        /// <summary>
        /// Queues a message to be sent to the MIDI port.
        /// </summary>
        public void Send(byte[] data, double timestamp) => JSRef.CallVoid("send", data, timestamp);
        /// <summary>
        /// Clears any pending send data from the queue.
        /// </summary>
        public void Clear() => JSRef.CallVoid("clear");
    }
}
