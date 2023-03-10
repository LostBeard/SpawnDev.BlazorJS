//using Microsoft.JSInterop;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Drawing;
//using System.Dynamic;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Text.Json;
//using System.Text.Json.Serialization;
//using System.Threading.Tasks;

//namespace SpawnDev.BlazorJS
//{
//    public class JSDynamicObjectConverter : JsonConverter<JSDynamicObject>
//    {
//        public override bool CanConvert(Type type)
//        {
//            return typeof(JSDynamicObject).IsAssignableFrom(type);
//        }
//        public override JSDynamicObject? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
//        {
//            var _ref = JsonSerializer.Deserialize<IJSInProcessObjectReference>(ref reader, options);
//            return _ref == null ? null : new JSDynamicObject(_ref);
//        }
//        public override void Write(Utf8JsonWriter writer, JSDynamicObject value, JsonSerializerOptions options)
//        {
//            var ext = value as JSDynamicObject;
//            JsonSerializer.Serialize(writer, ext?.JSRef, options);
//        }
//    }
//    [JsonConverter(typeof(JSDynamicObjectConverter))]
//    public class JSDynamicObject : DynamicObject, IDisposable
//    {
//        public IJSInProcessObjectReference? JSRef { get; private set; }
//        public bool IsDisposed { get; private set; }
//        public JSDynamicObject(IJSInProcessObjectReference _ref)
//        {
//            JSRef = _ref;
//        }
//        public JSDynamicObject(string className, params object?[]? args)
//        {
//            JSRef = JS.NewApply(className, args);
//            if (JSRef == null) throw new Exception($"Failed to create object {className}");
//        }
//        protected virtual void Dispose(bool disposing)
//        {
//            if (IsDisposed) return;
//            IsDisposed = true;
//            if (disposing)
//            {

//            }
//            // release reference to avoid memory leak
//            JSRef?.Dispose();
//            JSRef = null;
//        }
//        public virtual void Dispose()
//        {
//            if (IsDisposed) return;
//            Dispose(true);
//            GC.SuppressFinalize(this);
//        }
//        public static bool UndisposedHandleVerboseMode { get; set; } = false;
//        ~JSDynamicObject()
//        {
//            Dispose(false);
//        }
//        // DynamicObject
//        public override bool TrySetMember(SetMemberBinder binder, object? value)
//        {
//            JS._JSInteropCallVoid("_setProperty", JSRef, binder.Name, value);
//            return true;
//        }
//        // not used (must return false) - property getters must be called like methods with a T type specifier so we know what type to convert to
//        public override bool TryGetMember(GetMemberBinder binder, out object? result)
//        {
//            result = null;
//            return false;
//        }
//        private static Type s_csharpInvokePropertyType = typeof(Microsoft.CSharp.RuntimeBinder.RuntimeBinderException).Assembly.GetType("Microsoft.CSharp.RuntimeBinder.ICSharpInvokeOrInvokeMemberBinder");
//        private static Type[] GetTypeArgs(InvokeMemberBinder binder)
//        {
//            if (s_csharpInvokePropertyType.IsInstanceOfType(binder))
//            {
//                PropertyInfo typeArgsProperty = s_csharpInvokePropertyType.GetProperty("TypeArguments");
//                return ((IEnumerable<Type>)typeArgsProperty.GetValue(binder, null)).ToArray();
//            }
//            return new Type[0];
//        }
//        public override bool TryInvokeMember(InvokeMemberBinder binder, object?[]? args, out object? result)
//        {
//            Type[] callTypes = GetTypeArgs(binder);
//            if (JSRef == null || IsDisposed)
//            {
//                result = null;
//                return false;
//            }
//            if (binder.Name == "Dispose" && args.Length == 0)
//            {
//                result = null;
//                this.Dispose();
//                return true;
//            }
//            result = JS.GetDynamic(callTypes.Any() ? callTypes[0] : null, JSRef, binder.Name, args);
//            return true;
//        }
//    }
//}
