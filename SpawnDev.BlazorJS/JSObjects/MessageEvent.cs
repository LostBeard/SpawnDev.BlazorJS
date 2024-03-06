using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The MessageEvent interface represents a message received by a target object.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/MessageEvent
    /// </summary>
    public class MessageEvent : Event
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public MessageEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The data sent by the message emitter. (data property with TValue typed get accessor)
        /// </summary>
        /// <typeparam name="T">Type to get property as</typeparam>
        /// <returns></returns>
        public T GetData<T>() => JSRef.Get<T>("data");

        /// <summary>
        /// non-standard method returns the typeof this.data
        /// returns "String", "Blob", or "ArrayBuffer" (could also return "Object", "Boolean", "Number", other?)
        /// </summary>
        public string TypeOfData => JSRef.PropertyInstanceOf("data");

        public (string?, Blob?) GetTextOrBlob()
        {
            switch (TypeOfData)
            {
                case "String":
                    {
                        // use for returning error message(s)
                        return (GetData<string>(), null);
                    }
                case "ArrayBuffer":
                    {
                        using var arrayBuffer = GetData<ArrayBuffer>();
                        var blob = new Blob(new[] { arrayBuffer });
                        return (null, blob);
                    }
                case "Blob":
                    {
                        var blob = GetData<Blob>();
                        return (null, blob);
                    }
                default:
                    throw new Exception("Unexpected return type");
            }
        }

        public async Task<(string?, ArrayBuffer?)> GetTextOrArrayBuffer()
        {
            switch (TypeOfData)
            {
                case "String":
                    {
                        // use for returning error message(s)
                        return (GetData<string>(), null);
                    }
                case "ArrayBuffer":
                    {
                        return (null, GetData<ArrayBuffer>());
                    }
                case "Blob":
                    {
                        using var blob = GetData<Blob>();
                        return (null, await blob.ArrayBuffer());
                    }
                default:
                    throw new Exception("Unexpected return type");
            }
        }

        /// <summary>
        /// A string representing the origin of the message emitter.
        /// </summary>
        public string Origin => JSRef.Get<string>("origin");
        /// <summary>
        /// A string representing a unique ID for the event.
        /// </summary>
        public string LastEventId => JSRef.Get<string>("lastEventId");
        /// <summary>
        /// A MessageEventSource (which can be a WindowProxy, MessagePort, or ServiceWorker object) representing the message emitter. (source property with TValue typed get accessor)
        /// </summary>
        /// <typeparam name="T">Type to get property as</typeparam>
        /// <returns></returns>
        public T GetSource<T>() => JSRef.Get<T>("source");
        /// <summary>
        /// An array of MessagePort objects representing the ports associated with the channel the message is being sent through (where appropriate, e.g. in channel messaging or when sending a message to a shared worker).
        /// </summary>
        public Array<MessagePort> Ports => JSRef.Get<Array<MessagePort>>("ports");
    }
}
