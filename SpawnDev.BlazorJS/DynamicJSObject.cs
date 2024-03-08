using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;

namespace SpawnDev.BlazorJS
{

    public class DynamicJSObject : DynamicObject
    {
        static BlazorJSRuntime JS => BlazorJSRuntime.JS;
        public static implicit operator JSObject(DynamicJSObject obj) => obj.JSObjectRef;
        public JSObject JSObjectRef { get; private set; }
        public DynamicJSObject(JSObject obj)
        {
            JSObjectRef = obj;
        }
        public DynamicJSObject(IJSInProcessObjectReference _ref)
        {
            JSObjectRef = new JSObject(_ref);
        }
        public override IEnumerable<string> GetDynamicMemberNames()
        {
            Console.WriteLine("GetDynamicMemberNames");
            var keys = JSObjectRef.JSRef!.GetPropertyNames();
            return keys;
        }
        // object creation
        public override bool TryCreateInstance(CreateInstanceBinder binder, object?[]? args, [NotNullWhen(true)] out object? result)
        {
            Console.WriteLine("TryCreateInstance");
            result = new DynamicJSObject(JSObjectRef.JSRef!.NewApply(args));
            return true;
        }
        // method invoke
        public override bool TryInvoke(InvokeBinder binder, object?[]? args, out object? result)
        {
            Console.WriteLine($"TryInvoke");
            var csharpBinder = binder.GetType().GetInterface("Microsoft.CSharp.RuntimeBinder.ICSharpInvokeOrInvokeMemberBinder");
            var typeArgs = (csharpBinder.GetProperty("TypeArguments")!.GetValue(binder, null) as IList<Type>);
            result = JS.Call<JSObject?>("Reflect.apply", JSObjectRef.JSRef, Undefinable.Undefined, args);
            return true;
        }
        // object instance
        public override bool TryGetMember(GetMemberBinder binder, out object? result)
        {
            Console.WriteLine($"TryGetMember: {binder.Name}");
            var tmp = JSObjectRef.JSRef!.Get<JSObject?>(binder.Name);
            //var typeOf = tmp == null ? null : tmp.JSRef!.PropertyType();
            //switch (typeOf)
            //{
            //    case "string":
            //        result = tmp.JSRef!.As<string>();
            //        tmp.Dispose();
            //        return true;
            //    case "number":
            //        result = tmp.JSRef!.As<double>();
            //        tmp.Dispose();
            //        return true;
            //}
            result = tmp == null ? null : new DynamicJSObject(tmp);
            return true;
        }
        public override bool TrySetMember(SetMemberBinder binder, object? value)
        {
            Console.WriteLine($"TrySetMember: {binder.Name}");
            JSObjectRef.JSRef!.Set(binder.Name, value);
            return true;
        }
        public const string TypedAsPostfix = "__As";
        public override bool TryInvokeMember(InvokeMemberBinder binder, object?[]? args, out object? result)
        {
            Console.WriteLine($"TryInvokeMember: {binder.Name}");
            var csharpBinder = binder.GetType().GetInterface("Microsoft.CSharp.RuntimeBinder.ICSharpInvokeOrInvokeMemberBinder")!;
            var typeArgs = (csharpBinder.GetProperty("TypeArguments")!.GetValue(binder, null) as IList<Type>);
            var returnType = typeArgs != null && typeArgs.Count > 0 ? typeArgs[0] : null;
            var args0 = new List<object?>();
            if (args != null) args0.AddRange(args);

            if (returnType == null && args0.Count > 0 && args0[0] != null && args0[0] is Type argType)
            {
                returnType = argType;
                args0.RemoveAt(0);
            }
            if (returnType != null)
            {
                if (binder.Name.EndsWith(TypedAsPostfix))
                {
                    // typed getter for this object
                    var propName = binder.Name.Substring(0, binder.Name.Length - TypedAsPostfix.Length);
                    if (propName == "" && args0.Count > 0 && args0[0] != null && args0[0] is string args0Str && !string.IsNullOrEmpty(args0Str))
                    {
                        propName = args0Str;
                        args0.RemoveAt(0);
                    }
                    if (propName == "")
                    {
                        // obj.height__getAs<double>();
                        result = JSObjectRef.JSRef!.As(returnType);
                    }
                    else
                    {
                        // obj.height.__getAs<double>();
                        // obj.__getAs<double>("height");
                        result = JSObjectRef.JSRef!.Get(returnType, propName);
                    }
                }
                else
                {
                    // typed invoke
                    result = JSObjectRef.JSRef!.CallApply(returnType, binder.Name, args);
                }
            }
            else
            {
                // default invoke. returns DynamicJSObject or null.
                var tmp = JSObjectRef.JSRef!.CallApply<JSObject?>(binder.Name, args);
                result = tmp == null ? null : new DynamicJSObject(tmp);
            }
            return true;
        }
    }
}