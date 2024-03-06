using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    // https://developer.mozilla.org/en-US/docs/Web/API/RTCDataChannel
    // https://developer.mozilla.org/en-US/docs/Web/API/WebRTC_API/Simple_RTCDataChannel_sample
    /// <summary>
    /// The RTCDataChannel interface represents a network channel which can be used for bidirectional peer-to-peer transfers of arbitrary data. Every data channel is associated with an RTCPeerConnection, and each peer connection can have up to a theoretical maximum of 65,534 data channels (the actual limit may vary from browser to browser).<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/RTCDataChannel
    /// </summary>
    public class RTCDataChannel : EventTarget
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public RTCDataChannel(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns an ID number (between 0 and 65,534) which uniquely identifies the RTCDataChannel.
        /// </summary>
        public ushort Id => JSRef.Get<ushort>("id");
        /// <summary>
        /// Returns the number of bytes of data currently queued to be sent over the data channel.
        /// </summary>
        public long BufferedAmount => JSRef.Get<long>("bufferedAmount");
        /// <summary>
        /// Specifies the number of bytes of buffered outgoing data that is considered "low". The default value is 0.
        /// </summary>
        public long BufferedAmountLowThreshold { get => JSRef.Get<long>("bufferedAmountLowThreshold"); set => JSRef.Set("bufferedAmountLowThreshold", value); }
        /// <summary>
        /// Returns a string that contains a name describing the data channel. These labels are not required to be unique.
        /// </summary>
        public string Label => JSRef.Get<string>("label");
        /// <summary>
        /// Indicates whether or not the data channel guarantees in-order delivery of messages; the default is true, which indicates that the data channel is indeed ordered.
        /// </summary>
        public bool Ordered => JSRef.Get<bool>("ordered");
        /// <summary>
        /// Returns the amount of time, in milliseconds, the browser is allowed to take to attempt to transmit a message, as set when the data channel was created, or null
        /// </summary>
        public ushort? MaxPacketLifeTime => JSRef.Get<ushort?>("maxPacketLifeTime");
        /// <summary>
        /// Returns the maximum number of times the browser should try to retransmit a message before giving up, as set when the data channel was created, or null, which indicates that there is no maximum.
        /// </summary>
        public ushort? MaxRetransmits => JSRef.Get<ushort?>("maxRetransmits");
        /// <summary>
        /// Returns a string containing the name of the subprotocol in use. If no protocol was specified when the data channel was created, then this property's value is the empty string ("").
        /// </summary>
        public string Protocol => JSRef.Get<string>("protocol");
        /// <summary>
        /// Indicates whether the RTCDataChannel's connection was negotiated by the Web app (true) or by the WebRTC layer (false). The default is false.
        /// </summary>
        public bool Negotiated => JSRef.Get<bool>("negotiated");
        /// <summary>
        /// Returns a string which indicates the state of the data channel's underlying data connection. It can have one of the following values: connecting, open, closing, or closed.
        /// </summary>
        public string ReadyState => JSRef.Get<string>("readyState");
        /// <summary>
        /// Closes the RTCDataChannel. Either peer is permitted to call this method to initiate closure of the channel.
        /// </summary>
        public void Close() => JSRef.CallVoid("close");

        /// <summary>
        /// Uses BinaryType to determine the type of data to send. Chrome only does ArrayBuffer, Firefox prefers Blob (not sure if supports ArrayBuffer att)
        /// </summary>
        /// <param name="blob">Source data</param>
        public async Task SendAsBinaryType(Blob blob)
        {
            if (BinaryType == "blob")
            {
                Send(blob);
            }
            else if (BinaryType == "arraybuffer")
            {
                using var arrayBuffer = await blob.ArrayBuffer();
                Send(arrayBuffer);
            }
        }

        /// <summary>
        /// Uses BinaryType to determine the type of data to send. Chrome only does ArrayBuffer, Firefox prefers Blob (not sure if supports ArrayBuffer att)
        /// </summary>
        /// <param name="arrayBuffer">Source data... will be converted to Blob if BinaryType == "blob"</param>
        public void SendAsBinaryType(ArrayBuffer arrayBuffer)
        {
            switch (BinaryType)
            {
                case "blob":
                    {
                        using var blob = new Blob(new[] { arrayBuffer });
                        Send(blob);
                    }
                    break;
                case "arraybuffer":
                    Send(arrayBuffer);
                    break;
            }
        }

        /// <summary>
        /// Sends data across the data channel to the remote peer.
        /// </summary>
        /// <param name="data">The data to transmit across the connection. This may be a string, a Blob, an ArrayBuffer, a TypedArray or a DataView object.</param>
        public void Send(string data) => JSRef.CallVoid("send", data);
        /// <summary>
        /// Sends data across the data channel to the remote peer.
        /// </summary>
        /// <param name="data">The data to transmit across the connection. This may be a string, a Blob, an ArrayBuffer, a TypedArray or a DataView object.</param>
        public void Send(Blob data) => JSRef.CallVoid("send", data);
        /// <summary>
        /// Sends data across the data channel to the remote peer.
        /// </summary>
        /// <param name="data">The data to transmit across the connection. This may be a string, a Blob, an ArrayBuffer, a TypedArray or a DataView object.</param>
        public void Send(ArrayBuffer data) => JSRef.CallVoid("send", data);
        /// <summary>
        /// Sends data across the data channel to the remote peer.
        /// </summary>
        /// <param name="data">The data to transmit across the connection. This may be a string, a Blob, an ArrayBuffer, a TypedArray or a DataView object.</param>
        public void Send(byte[] data) => JSRef.CallVoid("send", data);
        /// <summary>
        /// Sends data across the data channel to the remote peer.
        /// </summary>
        /// <param name="data">The data to transmit across the connection. This may be a string, a Blob, an ArrayBuffer, a TypedArray or a DataView object.</param>
        public void Send(TypedArray data) => JSRef.CallVoid("send", data);
        /// <summary>
        /// Sends data across the data channel to the remote peer.
        /// </summary>
        /// <param name="data">The data to transmit across the connection. This may be a string, a Blob, an ArrayBuffer, a TypedArray or a DataView object.</param>
        public void Send(DataView data) => JSRef.CallVoid("send", data);
        /// <summary>
        /// A string specifying the type of object that should be used to represent binary data received on the RTCDataChannel. Values are the same as allowed on the WebSocket.binaryType property: blob if Blob objects are being used, or arraybuffer if ArrayBuffer objects are being used. The default is blob<br>
        /// NOTE: Chrome, as of 2023-07-01, does not support sending blobs and will return "arraybuffer" for this value... which can be used to decide what value types to send</br>
        /// CONT: An ArrayBuffer sent from Chrome will be received as a Blob in Firefox... Firefox returns "blob" for this property.
        /// </summary>
        public string BinaryType { get => JSRef.Get<string>("binaryType"); set => JSRef.Set("binaryType", value); }



        // TODO ... 
        // unless there is a compatibility issue ...
        // switch to JSEventCallback with AddEventListener instead of using property assigning which limits usage more... 
        // however, a lot of these events should only be handled by a single event handler but that should be up to the consuming code

        /// <summary>
        /// Sent when the number of bytes of data in the outgoing data buffer falls below the value specified by bufferedAmountLowThreshold.
        /// </summary>
        //public ActionCallback OnBufferedAmountLow { set { JSRef.Set("onbufferedamountlow", value); } }
        public JSEventCallback<Event> OnBufferedAmountLow { get => new JSEventCallback<Event>(JSRef, "onbufferedamountlow"); set { } }
        /// <summary>
        /// Sent when the underlying data transport closes.
        /// </summary>
        //public ActionCallback OnClose { set { JSRef.Set("onclose", value); } }
        public JSEventCallback<Event> OnClose { get => new JSEventCallback<Event>(JSRef, "onclose"); set { } }
        /// <summary>
        /// Sent when the underlying data transport is about to start closing.<br/>
        /// Note supported on Firefox as of 2023-07-01
        /// </summary>
        public JSEventCallback<Event> OnClosing { get => new JSEventCallback<Event>(JSRef, "onclosing"); set { } }
        /// <summary>
        /// Sent when an error occurs on the data channel.
        /// </summary>
        //public ActionCallback<RTCErrorEvent> OnError { set { JSRef.Set("onerror", value); } }
        public JSEventCallback<RTCErrorEvent> OnError { get => new JSEventCallback<RTCErrorEvent>(JSRef, "onerror"); set { } }
        /// <summary>
        /// Sent when a message has been received from the remote peer. The message contents can be found in the event's data property.
        /// </summary>
        //public ActionCallback<MessageEvent> OnMessage { set { JSRef.Set("onmessage", value); } }
        public JSEventCallback<MessageEvent> OnMessage { get => new JSEventCallback<MessageEvent>(JSRef, "onmessage"); set { } }
        /// <summary>
        /// Sent when the data channel is first opened, or when an existing data channel's underlying connection re-opens.
        /// </summary>
        //public ActionCallback OnOpen { set { JSRef.Set("onopen", value); } }
        public JSEventCallback<RTCDataChannelEvent> OnOpen { get => new JSEventCallback<RTCDataChannelEvent>(JSRef, "onopen"); set { } }
    }
}
