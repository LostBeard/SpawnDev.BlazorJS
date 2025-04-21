using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/PaymentRequestEvent/methodData#value
    /// </summary>
    public class PaymentMethodData : JSObject
    {
        /// <inheritdoc/>
        public PaymentMethodData(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Creates a new instance
        /// </summary>
        public PaymentMethodData() : base(JS.New("Object")) { }
        /// <summary>
        /// A payment method identifier for a payment method that the merchant website accepts.
        /// </summary>
        public string? SupportedMethods { get => JSRef!.Get<string?>("supportedMethods"); set => JSRef!.Set("supportedMethods", value); }
        /// <summary>
        /// An object that provides optional information that might be needed by the supported payment methods. If supplied, it will be JSON-serialized.
        /// </summary>
        public JSObject? Data { get => JSRef!.Get<JSObject?>("data"); set => JSRef!.Set("data", value); }
        /// <summary>
        /// Get data as T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetData<T>() => JSRef!.Get<T>("data");
        /// <summary>
        /// Set data value
        /// </summary>
        /// <param name="data"></param>
        public void SetData(object data) => JSRef!.Set("data", data);
    }
}
