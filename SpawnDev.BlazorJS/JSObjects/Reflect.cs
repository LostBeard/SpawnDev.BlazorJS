using Microsoft.JSInterop;
using Microsoft.VisualBasic;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Reflect
    /// </summary>
    public static class Reflect
    {
        static BlazorJSRuntime JS => BlazorJSRuntime.JS;
        /// <summary>
        /// Calls a target function with arguments as specified by the argumentsList parameter. See also Function.prototype.apply()
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">The target function to call.</param>
        /// <param name="thisArgument">The value of this provided for the call to target</param>
        /// <param name="argumentList">An array-like object specifying the arguments with which target should be called.</param>
        /// <returns>The result of calling the given target function with the specified this value and arguments.</returns>
        public static T Apply<T>(Function target, object? thisArgument, object[] argumentList) => JS.Call<T>("Reflect.apply", target, thisArgument, argumentList);
        /// <summary>
        /// Calls a target function with arguments as specified by the argumentsList parameter. See also Function.prototype.apply()
        /// </summary>
        /// <param name="target">The target function to call.</param>
        /// <param name="thisArgument">The value of this provided for the call to target</param>
        /// <param name="argumentList">An array-like object specifying the arguments with which target should be called.</param>
        public static void ApplyVoid(Function target, object? thisArgument, object[] argumentList) => JS.CallVoid("Reflect.apply", target, thisArgument, argumentList);
        /// <summary>
        /// The Reflect.construct() static method is like the new operator, but as a function. It is equivalent to calling new target(...args). It gives also the added option to specify a different new.target value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">The target function to call.</param>
        /// <param name="argumentList">An array-like object specifying the arguments with which target should be called.</param>
        /// <returns>A new instance of target (or newTarget, if present), initialized by target as a constructor with the given argumentsList.</returns>
        public static T Construct<T>(Function target, object[] argumentList) => JS.Call<T>("Reflect.construct", target, argumentList);
        /// <summary>
        /// The Reflect.construct() static method is like the new operator, but as a function. It is equivalent to calling new target(...args). It gives also the added option to specify a different new.target value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">The target function to call.</param>
        /// <param name="argumentList">An array-like object specifying the arguments with which target should be called.</param>
        /// <param name="newTarget">The value of new.target operator, which usually specifies the prototype of the returned object. If newTarget is not present, its value defaults to target.</param>
        /// <returns>A new instance of target (or newTarget, if present), initialized by target as a constructor with the given argumentsList.</returns>
        public static T Construct<T>(Function target, object[] argumentList, Function newTarget) => JS.Call<T>("Reflect.construct", target, argumentList, newTarget);
        /// <summary>
        /// The Reflect.defineProperty() static method is like Object.defineProperty() but returns a Boolean
        /// </summary>
        /// <param name="target">The target object on which to define the property.</param>
        /// <param name="propertyKey">The name of the property to be defined or modified</param>
        /// <param name="attributes">The attributes for the property being defined or modified.</param>
        /// <returns>A boolean indicating whether or not the property was successfully defined.</returns>
        public static bool DefineProperty(Union<JSObject, IJSInProcessObjectReference> target, string propertyKey, object attributes) => JS.Call<bool>("Reflect.defineProperty", target, propertyKey, attributes);
        /// <summary>
        /// The Reflect.deleteProperty() static method is like the delete operator, but as a function. It deletes a property from an object.
        /// </summary>
        /// <param name="target">The target object on which to delete the property.</param>
        /// <param name="propertyKey">The name of the property to be deleted.</param>
        /// <returns>A boolean indicating whether or not the property was successfully deleted.</returns>
        public static bool DeleteProperty(Union<JSObject, IJSInProcessObjectReference> target, string propertyKey) => JS.Call<bool>("Reflect.deleteProperty", target, propertyKey);
        /// <summary>
        /// The Reflect.deleteProperty() static method is like the delete operator, but as a function. It deletes a property from an object.
        /// </summary>
        /// <param name="target">The target object on which to delete the property.</param>
        /// <param name="propertyKey">The name of the property to be deleted.</param>
        /// <returns>A boolean indicating whether or not the property was successfully deleted.</returns>
        public static bool DeleteProperty(Union<JSObject, IJSInProcessObjectReference> target, int propertyKey) => JS.Call<bool>("Reflect.deleteProperty", target, propertyKey);
        /// <summary>
        /// The Reflect.get() static method is like the property accessor syntax, but as a function.
        /// </summary>
        /// <typeparam name="T">Return type</typeparam>
        /// <param name="target">The target object on which to get the property.</param>
        /// <param name="propertyKey">The name of the property to get.</param>
        /// <returns>The value of the property.</returns>
        public static T Get<T>(Union<JSObject, IJSInProcessObjectReference> target, string propertyKey) => JS.Call<T>("Reflect.get", target, propertyKey);
        /// <summary>
        /// The Reflect.get() static method is like the property accessor syntax, but as a function.
        /// </summary>
        /// <typeparam name="T">Return type</typeparam>
        /// <param name="target">The target object on which to get the property.</param>
        /// <param name="propertyKey">The name of the property to get.</param>
        /// <param name="receiver">The value of this provided for the call to target if a getter is encountered.</param>
        /// <returns>The value of the property.</returns>
        public static T Get<T>(Union<JSObject, IJSInProcessObjectReference> target, int propertyKey, Union<JSObject, IJSInProcessObjectReference> receiver) => JS.Call<T>("Reflect.get", target, propertyKey, receiver);
        /// <summary>
        /// The Reflect.get() static method is like the property accessor syntax, but as a function.
        /// </summary>
        /// <typeparam name="T">Return type</typeparam>
        /// <param name="target">The target object on which to get the property.</param>
        /// <param name="propertyKey">The name of the property to get.</param>
        /// <returns>The value of the property.</returns>
        public static T Get<T>(Union<JSObject, IJSInProcessObjectReference> target, int propertyKey) => JS.Call<T>("Reflect.get", target, propertyKey);
        /// <summary>
        /// The Reflect.get() static method is like the property accessor syntax, but as a function.
        /// </summary>
        /// <typeparam name="T">Return type</typeparam>
        /// <param name="target">The target object on which to get the property.</param>
        /// <param name="propertyKey">The name of the property to get.</param>
        /// <param name="receiver">The value of this provided for the call to target if a getter is encountered.</param>
        /// <returns>The value of the property.</returns>
        public static T Get<T>(Union<JSObject, IJSInProcessObjectReference> target, string propertyKey, Union<JSObject, IJSInProcessObjectReference> receiver) => JS.Call<T>("Reflect.get", target, propertyKey, receiver);
        /// <summary>
        /// The Reflect.getOwnPropertyDescriptor() static method is like Object.getOwnPropertyDescriptor(). It returns a property descriptor of the given property if it exists on the object, undefined otherwise.
        /// </summary>
        /// <param name="target">The target object in which to look for the property</param>
        /// <param name="propertyKey">The name of the property to get an own property descriptor for.</param>
        /// <returns>A property descriptor object if the property exists as an own property of target; otherwise, undefined.</returns>
        public static PropertyDescriptor? GetOwnPropertyDescriptor(Union<JSObject, IJSInProcessObjectReference> target, string propertyKey) => JS.Call<PropertyDescriptor?>("Reflect.getOwnPropertyDescriptor", target, propertyKey);
        /// <summary>
        /// The Reflect.getPrototypeOf() static method is like Object.getPrototypeOf(). It returns the prototype of the specified object.
        /// </summary>
        /// <param name="target">The target object of which to get the prototype.</param>
        /// <returns>The prototype of the given object, which may be an object or null</returns>
        public static JSObject? GetPrototypeOf(Union<JSObject, IJSInProcessObjectReference> target) => JS.Call<JSObject?>("Reflect.getPrototypeOf", target);
        /// <summary>
        /// The Reflect.has() static method is like the in operator, but as a function.
        /// </summary>
        /// <param name="target">The target object in which to look for the property.</param>
        /// <param name="propertyKey">The name of the property to check.</param>
        /// <returns>A Boolean indicating whether or not the target has the property.</returns>
        public static bool Has(Union<JSObject, IJSInProcessObjectReference> target, string propertyKey) => JS.Call<bool>("Reflect.has", target, propertyKey);
        /// <summary>
        /// The Reflect.isExtensible() static method is like Object.isExtensible(). It determines if an object is extensible (whether it can have new properties added to it).
        /// </summary>
        /// <param name="target">The target object which to check if it is extensible.</param>
        /// <returns>A Boolean indicating whether or not the target is extensible.</returns>
        public static bool IsExtensible(Union<JSObject, IJSInProcessObjectReference> target) => JS.Call<bool>("Reflect.isExtensible", target);
        /// <summary>
        /// The Reflect.ownKeys() static method returns an array of the target object's own property keys.
        /// </summary>
        /// <param name="target">The target object from which to get the own keys.</param>
        /// <returns>An Array of the target object's own property keys, including strings and symbols. For most objects, the array will be in the order of:<br/>
        /// 1. Non-negative integer indexes in increasing numeric order(but as strings)<br/>
        /// 2. Other string keys in the order of property creation<br/>
        /// 3. Symbol keys in the order of property creation.<br/>
        /// An untyped Array is returned because the array can contain strings and symbols.
        /// </returns>
        public static Array OwnKeys(Union<JSObject, IJSInProcessObjectReference> target) => JS.Call<Array>("Reflect.ownKeys", target);
        /// <summary>
        /// The Reflect.preventExtensions() static method is like Object.preventExtensions(). It prevents new properties from ever being added to an object (i.e., prevents future extensions to the object).
        /// </summary>
        /// <param name="target">The target object on which to prevent extensions.</param>
        /// <returns>A Boolean indicating whether or not the target was successfully set to prevent extensions.</returns>
        public static bool PreventExtensions(Union<JSObject, IJSInProcessObjectReference> target) => JS.Call<bool>("Reflect.preventExtensions", target);
        /// <summary>
        /// The Reflect.set() static method is like the property accessor and assignment syntax, but as a function.
        /// </summary>
        /// <param name="target">The target object on which to set the property.</param>
        /// <param name="propertyKey">The name of the property to set.</param>
        /// <param name="value">The value to set.</param>
        /// <returns>A Boolean indicating whether or not setting the property was successful.</returns>
        public static bool Set(Union<JSObject, IJSInProcessObjectReference> target, string propertyKey, object value) => JS.Call<bool>("Reflect.set", target, propertyKey, value);
        /// <summary>
        /// The Reflect.set() static method is like the property accessor and assignment syntax, but as a function.
        /// </summary>
        /// <param name="target">The target object on which to set the property.</param>
        /// <param name="propertyKey">The name of the property to set.</param>
        /// <param name="value">The value to set.</param>
        /// <param name="receiver">The value of this provided for the call to the setter for propertyKey on target. If provided and target does not have a setter for propertyKey, the property will be set on receiver instead.</param>
        /// <returns>A Boolean indicating whether or not setting the property was successful.</returns>
        public static bool Set(Union<JSObject, IJSInProcessObjectReference> target, string propertyKey, object value, Union<JSObject, IJSInProcessObjectReference> receiver) => JS.Call<bool>("Reflect.set", target, propertyKey, value, receiver);
        /// <summary>
        /// The Reflect.setPrototypeOf() static method is like Object.setPrototypeOf() but returns a Boolean. It sets the prototype (i.e., the internal [[Prototype]] property) of a specified object.
        /// </summary>
        /// <param name="target">The target object of which to set the prototype.</param>
        /// <param name="prototype">The object's new prototype (an object or null).</param>
        /// <returns>A Boolean indicating whether or not the prototype was successfully set.</returns>
        public static bool SetPrototypeOf(Union<JSObject, IJSInProcessObjectReference> target, Union<JSObject, IJSInProcessObjectReference> prototype) => JS.Call<bool>("Reflect.setPrototypeOf", target, prototype);
    }
}
