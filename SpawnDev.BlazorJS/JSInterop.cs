using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS
{
    public static partial class JS
    {
        public static void _JSInteropCallVoid(string fn, params object?[] args)
        {
            AssertInit();
            _js.InvokeVoid($"JSInterop.{fn}", args);
        }
        public static T _JSInteropCall<T>(string fn, params object?[] args)
        {
            AssertInit();
            T? ret = default;
            var returnType = typeof(T);
            var isArray = returnType.IsArray;
            var elementType = returnType.HasElementType ? returnType.GetElementType() : returnType;
            var returnTypeIsJSObjectAssignable = typeof(JSObject).IsAssignableFrom(returnType);
            var elementTypeIsJSObjectAssignable = typeof(JSObject).IsAssignableFrom(elementType);
            var elementTypeIsIJSInProcessObjectAssignable = typeof(IJSInProcessObjectReference).IsAssignableFrom(elementType);
            var useIteration = isArray && (elementTypeIsJSObjectAssignable || elementTypeIsIJSInProcessObjectAssignable);
            if (useIteration)
            {
                using var _refArray = _js.Invoke<IJSInProcessObjectReference>($"JSInterop.{fn}", args);
                var length = _refArray.Get<int>("length");
                var tmpRet = Array.CreateInstance(elementType, length);
                for (var i = 0; i < length; i++)
                {
                    var value = _refArray.Get(elementType, i);
                    tmpRet.SetValue(value, i);
                }
                ret = (T)(object)tmpRet;
            }
            else if (returnTypeIsJSObjectAssignable)
            {
                var _ref = _js.Invoke<IJSInProcessObjectReference>($"JSInterop.{fn}", args);
                ret = (T)Activator.CreateInstance(returnType, _ref);
            }
            else
            {
                ret = _js.Invoke<T>($"JSInterop.{fn}", args);
            }
            return ret;
        }
        public static object? _JSInteropCall(Type returnType, string fn, params object?[] args)
        {
            AssertInit();
            object? ret = null;
            var isArray = returnType.IsArray;
            var elementType = returnType.HasElementType ? returnType.GetElementType() : returnType;
            var returnTypeIsJSObjectAssignable = typeof(JSObject).IsAssignableFrom(returnType);
            var elementTypeIsJSObjectAssignable = typeof(JSObject).IsAssignableFrom(elementType);
            var elementTypeIsIJSInProcessObjectAssignable = typeof(IJSInProcessObjectReference).IsAssignableFrom(elementType);
            var useIteration = isArray && (elementTypeIsJSObjectAssignable || elementTypeIsIJSInProcessObjectAssignable);
            if (useIteration)
            {
                using var _refArray = _js.Invoke<IJSInProcessObjectReference>($"JSInterop.{fn}", args);
                var length = _refArray.Get<int>("length");
                var tmpRet = Array.CreateInstance(elementType, length);
                for (var i = 0; i < length; i++)
                {
                    var value = _refArray.Get(elementType, i);
                    tmpRet.SetValue(value, i);
                }
                ret = tmpRet;
            }
            else if (returnTypeIsJSObjectAssignable)
            {
                var _ref = _js.Invoke<IJSInProcessObjectReference>($"JSInterop.{fn}", args);
                ret = Activator.CreateInstance(returnType, _ref);
            }
            else
            {
                ret = _js.Invoke(returnType, $"JSInterop.{fn}", args);
            }
            return ret;
        }
        public static async ValueTask _JSInteropCallVoidAsync(string fn, params object?[] args)
        {
            AssertInit();
            await _js.InvokeVoidAsync($"JSInterop.{fn}", args);
        }
        public static async ValueTask<T> _JSInteropCallAsync<T>(string fn, params object?[] args)
        {
            AssertInit();
            T? ret = default;
            var returnType = typeof(T);
            var isArray = returnType.IsArray;
            var elementType = returnType.HasElementType ? returnType.GetElementType() : returnType;
            var returnTypeIsJSObjectAssignable = typeof(JSObject).IsAssignableFrom(returnType);
            var elementTypeIsJSObjectAssignable = typeof(JSObject).IsAssignableFrom(elementType);
            var elementTypeIsIJSInProcessObjectAssignable = typeof(IJSInProcessObjectReference).IsAssignableFrom(elementType);
            var useIteration = isArray && (elementTypeIsJSObjectAssignable || elementTypeIsIJSInProcessObjectAssignable);
            if (useIteration)
            {
                using var _refArray = await _js.InvokeAsync<IJSInProcessObjectReference>($"JSInterop.{fn}", args);
                var length = _refArray.Get<int>("length");
                var tmpRet = Array.CreateInstance(elementType, length);
                for (var i = 0; i < length; i++)
                {
                    var value = _refArray.Get(elementType, i);
                    tmpRet.SetValue(value, i);
                }
                ret = (T)(object)tmpRet;
            }
            else if (returnTypeIsJSObjectAssignable)
            {
                var _ref = await _js.InvokeAsync<IJSInProcessObjectReference>($"JSInterop.{fn}", args);
                ret = (T)Activator.CreateInstance(returnType, _ref);
            }
            else
            {
                ret = await _js.InvokeAsync<T>($"JSInterop.{fn}", args);
            }
            return ret;
        }
        public static async ValueTask<object?> _JSInteropCallAsync(Type returnType, string fn, params object?[] args)
        {
            AssertInit();
            object? ret = null;
            var isArray = returnType.IsArray;
            var elementType = returnType.HasElementType ? returnType.GetElementType() : returnType;
            var returnTypeIsJSObjectAssignable = typeof(JSObject).IsAssignableFrom(returnType);
            var elementTypeIsJSObjectAssignable = typeof(JSObject).IsAssignableFrom(elementType);
            var elementTypeIsIJSInProcessObjectAssignable = typeof(IJSInProcessObjectReference).IsAssignableFrom(elementType);
            var useIteration = isArray && (elementTypeIsJSObjectAssignable || elementTypeIsIJSInProcessObjectAssignable);
            if (useIteration)
            {
                using var _refArray = await _js.InvokeAsync<IJSInProcessObjectReference>($"JSInterop.{fn}", args);
                var length = _refArray.Get<int>("length");
                var tmpRet = Array.CreateInstance(elementType, length);
                for (var i = 0; i < length; i++)
                {
                    var value = _refArray.Get(elementType, i);
                    tmpRet.SetValue(value, i);
                }
                ret = tmpRet;
            }
            else if (returnTypeIsJSObjectAssignable)
            {
                var _ref = await _js.InvokeAsync<IJSInProcessObjectReference>($"JSInterop.{fn}", args);
                ret = Activator.CreateInstance(returnType, _ref);
            }
            else
            {
                ret = await _js.InvokeAsync(returnType, $"JSInterop.{fn}", args);
            }
            return ret;
        }
    }
}
