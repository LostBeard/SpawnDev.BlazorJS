using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;

namespace SpawnDev.BlazorJS
{
    /// <summary>
    /// When cast to dynamic, a DynamicJSObject instance is usable in a very similar way to Javascript.<br />
    /// Results from property getters and method calls are also wrapped in DynamicJSObjects or null.<br />
    /// To unwrap a DynamicJSObject call <br />
    /// - obj._As&lt;T&gt;() -- returns obj as Type T<br />
    /// - obj._As(type) -- returns obj as Type type<br />
    /// - obj.height_As&lt;T&gt;() -- returns obj.height as Type T<br />
    /// - obj.height_As(type) -- returns obj.height as Type type<br />
    /// </summary>
    public class DynamicJSObject : DynamicObject
    {
        static BlazorJSRuntime JS => BlazorJSRuntime.JS;
        public static implicit operator JSObject(DynamicJSObject obj) => obj.JSObjectRef;
        public static explicit operator DynamicJSObject(JSObject obj) => new DynamicJSObject(obj);
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
            //Console.WriteLine("GetDynamicMemberNames");
            var keys = JSObjectRef.JSRef!.GetPropertyNames();
            return keys;
        }
        // method invoke
        public override bool TryInvoke(InvokeBinder binder, object?[]? args, out object? result)
        {
            //Console.WriteLine($"TryInvoke");
            var csharpBinder = binder.GetType().GetInterface("Microsoft.CSharp.RuntimeBinder.ICSharpInvokeOrInvokeMemberBinder");
            var typeArgs = (csharpBinder.GetProperty("TypeArguments")!.GetValue(binder, null) as IList<Type>);
            var returnType = typeArgs != null && typeArgs.Count > 0 ? typeArgs[0] : null;
            var args0 = new List<object?>();
            if (args != null) args0.AddRange(args);
            if (returnType == null && args0.Count > 0 && args0[0] != null && args0[0] is Type argType)
            {
                returnType = argType;
                args0.RemoveAt(0);
            }
            if (returnType == null)
            {
                // default invoke. returns DynamicJSObject or null.
                var tmp = JS.Call<JSObject?>("Reflect.apply", JSObjectRef.JSRef, Undefinable.Undefined, args);
                result = tmp == null ? null : new DynamicJSObject(tmp);
            }
            else
            {
                result = JS.Call(returnType, "Reflect.apply", JSObjectRef.JSRef, Undefinable.Undefined, args);
            }
            return true;
        }
        // object instance
        public override bool TryGetMember(GetMemberBinder binder, out object? result)
        {
            //Console.WriteLine($"TryGetMember: {binder.Name}");
            var tmp = JSObjectRef.JSRef!.Get<JSObject?>(binder.Name);
            result = tmp == null ? null : new DynamicJSObject(tmp);
            return true;
        }
        public override bool TrySetMember(SetMemberBinder binder, object? value)
        {
            //Console.WriteLine($"TrySetMember: {binder.Name}");
            JSObjectRef.JSRef!.Set(binder.Name, value);
            return true;
        }
        public const string TypedAsPostfix = "__As";
        public override bool TryInvokeMember(InvokeMemberBinder binder, object?[]? args, out object? result)
        {
            //Console.WriteLine($"TryInvokeMember: {binder.Name}");
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