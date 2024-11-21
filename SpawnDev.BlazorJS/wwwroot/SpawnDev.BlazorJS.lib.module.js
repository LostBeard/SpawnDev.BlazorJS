(function () {
    class BlazorJSInterop {
        constructor() {
            this.callbacks = {};
            this.asyncCallbacks = {};
        }
        // *************************************************
        // ************ Object Property Methods ************
        // *************************************************
        // returns bool
        ObjectPropertyEquals(obj, key, obj2, full) {
            if (obj === void 0 || obj === null) throw new Error('obj null or undefined');
            var { target, shortCircuit } = this.pathObjectInfo(obj, key);
            return full ? target === obj2 : target == obj2;
        }
        // returns string
        ObjectPropertyTypeOf(obj, key) {
            if (obj === void 0 || obj === null) throw new Error('obj null or undefined');
            var { target, shortCircuit } = this.pathObjectInfo(obj, key);
            return typeof target;
        }
        // returns string or undefined
        ObjectPropertyConstructorName(obj, key) {
            if (obj === void 0 || obj === null) throw new Error('obj null or undefined');
            var { target, shortCircuit } = this.pathObjectInfo(obj, key);
            return target?.constructor?.name;
        }
        // returns string[]
        ObjectPropertyConstructorNames(obj, key) {
            if (obj === void 0 || obj === null) throw new Error('obj null or undefined');
            var { target, shortCircuit } = this.pathObjectInfo(obj, key);
            return this.ObjectConstructorNames(target);
        }
        // returns any
        ObjectPropertyCall(obj, key, args) {
            if (obj === void 0 || obj === null) throw new Error('obj null or undefined');
            var { target, parent, shortCircuit } = this.pathObjectInfo(obj, key);
            if (shortCircuit) return;
            return target.apply(parent, args);
        }
        // returns any
        ObjectPropertyNew(obj, key, args) {
            if (obj === void 0 || obj === null) throw new Error('obj null or undefined');
            var { target, shortCircuit } = this.pathObjectInfo(obj, key);
            if (shortCircuit) return;
            return args ? new target(...args) : new target();
        }
        // returns string[]
        ObjectPropertyKeys(obj, key, hasOwnProperty) {
            if (obj === void 0 || obj === null) throw new Error('obj null or undefined');
            var { target, shortCircuit } = this.pathObjectInfo(obj, key);
            var keys = [];
            if (hasOwnProperty && target.hasOwnProperty) {
                for (var k in target) {
                    if (typeof k !== 'string') continue;
                    if (target.hasOwnProperty(k)) {
                        keys.push(k);
                    }
                }
                var ownKeys = Reflect.ownKeys(target).filter(o => typeof o === 'string');
                for (var k of ownKeys) {
                    if (keys.indexOf(k) == -1 && target.hasOwnProperty(k)) {
                        keys.push(k);
                    }
                }
            } else {
                for (var k in target) {
                    if (typeof k !== 'string') continue;
                    keys.push(k);
                }
                var ownKeys = Reflect.ownKeys(target).filter(o => typeof o === 'string');
                for (var k of ownKeys) {
                    if (keys.indexOf(k) == -1) {
                        keys.push(k);
                    }
                }
            }
            return keys;
        }
        // returns bool
        ObjectPropertyInstanceOf(obj, key, type) {
            if (obj === void 0 || obj === null) throw new Error('obj null or undefined');
            var { target, shortCircuit } = this.pathObjectInfo(obj, key);
            return target instanceof type;
        }
        // returns any - the value of the property
        ObjectPropertyGet(obj, key) {
            var ret = null;
            if (obj === void 0 || obj === null) throw new Error('obj null or undefined');
            var { target, parent, shortCircuit } = this.pathObjectInfo(obj, key);
            if (typeof target === "function") {
                ret = target.bind(parent);
            } else {
                ret = target;
            }
            return ret;
        }
        // returns undefined
        ObjectPropertySet(obj, key, value) {
            if (obj === void 0 || obj === null) throw new Error('obj null or undefined');
            var { parent, propertyName, shortCircuit } = this.pathObjectInfo(obj, key);
            if (shortCircuit) return;
            parent[propertyName] = value;
        }
        // returns bool
        ObjectPropertyDelete(obj, key) {
            if (obj === void 0 || obj === null) throw new Error('obj null or undefined');
            var { parent, propertyName, shortCircuit } = this.pathObjectInfo(obj, key);
            if (shortCircuit) return true;
            return delete parent[propertyName];
        }
        // returns bool
        ObjectPropertyIn(obj, key) {
            if (obj === void 0 || obj === null) throw new Error('obj null or undefined');
            var { parent, shortCircuit } = this.pathObjectInfo(obj, key);
            if (shortCircuit) return false;
            return key in parent;
        }
        // *****************************************************
        // ************ globalThis Property Methods ************
        // *****************************************************
        // returns bool
        GlobalPropertyEquals(key, obj2, full) {
            return this.ObjectPropertyEquals(globalThis, key, obj2, full);
        }
        // returns string
        GlobalPropertyTypeOf(key) {
            return this.ObjectPropertyTypeOf(globalThis, key);
        }
        // returns string or null
        GlobalPropertyConstructorName(key) {
            return this.ObjectPropertyConstructorName(globalThis, key);
        }
        // returns string or null
        GlobalPropertyConstructorNames(key) {
            return this.ObjectPropertyConstructorNames(globalThis, key);
        }
        // returns string or null
        GlobalConstructorName() {
            return this.ObjectConstructorName(globalThis);
        }
        // returns string[]
        GlobalConstructorNames() {
            return this.ObjectConstructorNames(globalThis);
        }
        // returns any
        GlobalPropertyCall(key, args) {
            switch (key) {
                case 'import': return import(args[0]);
            }
            return this.ObjectPropertyCall(globalThis, key, args);
        }
        // returns any
        GlobalPropertyNew(key, args) {
            return this.ObjectPropertyNew(globalThis, key, args);
        }
        // returns string[]
        GlobalPropertyKeys(key, hasOwnProperty) {
            return this.ObjectPropertyKeys(globalThis, key, hasOwnProperty);
        }
        // returns string[]
        GlobalKeys(hasOwnProperty) {
            return this.ObjectKeys(globalThis, hasOwnProperty);
        }
        // returns bool
        GlobalPropertyInstanceOf(key, type) {
            return this.ObjectPropertyInstanceOf(globalThis, key, type);
        }
        // returns the value of the property
        GlobalPropertyGet(key) {
            return this.ObjectPropertyGet(globalThis, key);
        }
        // returns undefined
        GlobalPropertySet(key, value) {
            return this.ObjectPropertySet(globalThis, key, value);
        }
        // returns bool
        GlobalPropertyDelete(key) {
            return this.ObjectPropertyDelete(globalThis, key);
        }
        // returns bool
        GlobalPropertyIn(key) {
            return this.ObjectPropertyIn(globalThis, key);
        }
        // ****************************************
        // ************ Object Methods ************
        // ****************************************
        // returns bool
        ObjectEquals(obj, obj2, full) {
            return full ? obj === obj2 : obj == obj2;
        }
        // returns string
        ObjectTypeOf(obj) {
            return typeof obj;
        }
        // returns string or null
        ObjectConstructorName(obj) {
            return obj?.constructor?.name;
        }
        // returns string[]
        ObjectConstructorNames(obj) {
            var constructorNames = [];
            if (obj === void 0 || obj === null) return constructorNames;
            var o = obj;
            var cName;
            while (1) {
                o = Object.getPrototypeOf(o);
                cName = o?.constructor?.name;
                if (!cName) break;
                if (constructorNames.indexOf(cName) !== -1) continue;
                constructorNames.push(cName);
            }
            return constructorNames;
        }
        // returns any
        ObjectCall(obj, args) {
            return obj.apply(null, args);
        }
        // returns any
        ObjectNew(obj, args) {
            return args ? new obj(...args) : new obj();
        }
        // returns string[]
        ObjectKeys(obj, hasOwnProperty) {
            if (obj === void 0 || obj === null) throw new Error('obj null or undefined');
            var keys = [];
            if (hasOwnProperty && obj.hasOwnProperty) {
                for (var k in obj) {
                    if (obj.hasOwnProperty(k)) {
                        if (typeof k !== 'string') continue;
                        keys.push(k);
                    }
                }
                var ownKeys = Reflect.ownKeys(obj).filter(o => typeof o === 'string');
                for (var k of ownKeys) {
                    if (keys.indexOf(k) == -1 && obj.hasOwnProperty(k)) {
                        keys.push(k);
                    }
                }
            } else {
                for (var k in obj) {
                    if (typeof k !== 'string') continue;
                    keys.push(k);
                }
                var ownKeys = Reflect.ownKeys(obj).filter(o => typeof o === 'string');
                for (var k of ownKeys) {
                    if (keys.indexOf(k) == -1) {
                        keys.push(k);
                    }
                }
            }
            return keys;
        }
        // returns bool
        ObjectInstanceOf(obj, type) {
            return obj instanceof type;
        }
        // returns any
        ObjectGet(obj) {
            return obj;
        }
        // returns null or long[]
        ObjectToDotNetRefArray(obj) {
            if (obj === null || obj === void 0) return null;
            var ret = [];
            for (var o of obj) ret.push(o === null || o === void 0 ? -1 : this.createJSObjectReference(o).__jsObjectId);
            return ret;
        }
        // ******************************************
        // ************ Callback Methods ************
        // ******************************************
        DisposeCallback(callbackId) {
            if (this.callbacks[callbackId]) delete this.callbacks[callbackId];
        }
        DisposeCallbackAsync(callbackAsyncId) {
            if (this.asyncCallbacks[callbackAsyncId]) delete this.asyncCallbacks[callbackAsyncId];
        }
        // ****************************************
        // ************ Invoke Method *************
        // ****************************************
        // the below 2 methods are the only Javascript methods that the C# BlazorJSRuntime will call.
        // it is used to call other Javascript BlazorJSInterop methods and prepare the return value for C#
        Invoke(fnName, args, returnType) {
            var ret = this[fnName](...args);
            if (returnType === void 0 || returnType === null) return;
            return this.serializeToDotNet(ret, returnType);
        }
        async InvokeAsync(fnName, args, returnType) {
            var ret = await this[fnName](...args);
            if (returnType === void 0 || returnType === null) return;
            return this.serializeToDotNet(ret, returnType);
        }
        // ****************************************
        // ************ Internal Methods **********
        // ****************************************
        createJSObjectReference(o) {
            var mustWrap = this.createJSObjectReferenceMustWrapType(o);
            if (mustWrap) o = this.wrapJSObject(o);
            return DotNet.createJSObjectReference(o);
        }
        wrapJSObject(o) {
            return { __wrappedJSObject: o };
        }
        serializeToDotNet(value, returnType) {
            var typeOfValue = typeof value;
            if (typeOfValue === 'undefined') {
                typeOfValue = 'object';
                value = null;
            }
            if (!returnType) {
                return value;
            }
            var isOverridden = returnType >= 128;
            var desiredType = isOverridden ? returnType - 128 : returnType;
            switch (desiredType) {
                case DotNet.JSCallResultType.Default:
                    break;
                case DotNet.JSCallResultType.JSObjectReference:
                    if (this.createJSObjectReferenceMustWrapType(typeOfValue)) {
                        value = this.wrapJSObject(value);
                    }
                    break;
                case DotNet.JSCallResultType.JSStreamReference:
                    break;
                case DotNet.JSCallResultType.JSVoidResult:
                    break;
                default:
                    break;
            }
            if (!isOverridden) {
                return value;
            }
            // overridden so serialize it here
            switch (desiredType) {
                case DotNet.JSCallResultType.Default:
                    return value;
                case DotNet.JSCallResultType.JSObjectReference:
                    return value === null ? null : DotNet.createJSObjectReference(value);
                case DotNet.JSCallResultType.JSStreamReference:
                    {
                        // TODO test and fix if needed
                        var n = DotNet.createJSStreamReference(value);
                        var r = JSON.stringify(n);
                        return BINDING.js_string_to_mono_string(r)
                    }
                case DotNet.JSCallResultType.JSVoidResult:
                    return null;
                default:
                    throw new Error(`Invalid JS call result type '${a}'.`)
            }
        }
        createJSObjectReferenceMustWrapType(typeofValue) {
            switch (typeofValue) {
                case 'object':
                    return false;
                    break;
                case 'symbol':
                case 'function':
                case 'string':
                    return true;
                    break;
                default:
                    return true;
                    break;
            }
        }
        pathObjectInfo(rootObject, path) {
            if (rootObject === null || rootObject === void 0) {
                // callers must call with the globalThis if they wish to use it as the rootObject.
                throw new DOMException('blazorJSInterop.pathObjectInfo error: rootObject cannot be null');
            }
            var parent = rootObject;
            var target;
            var propertyName;
            var shortCircuit = false;
            if (typeof path === 'string' && !(path in parent)) {
                var parts = path.split('.');
                propertyName = parts[parts.length - 1];
                var part;
                for (var i = 0; i < parts.length - 1; i++) {
                    part = parts[i];
                    if (part[part.length - 1] === '?') {
                        // ? null conditonal found
                        // if parent does not exist allow undefined/null parent instead of throwing exception
                        part = part.substring(0, part.length - 1);
                        parent = parent[part];
                        if (parent === void 0 || parent === null) {
                            shortCircuit = true;
                            break;
                        }
                    }
                    else {
                        parent = parent[part];
                    }
                }
                if (!shortCircuit) {
                    target = parent[propertyName];
                }
            }
            else {
                propertyName = path;
                target = parent[propertyName];
            }
            return {
                shortCircuit,   // bool - true if the pathfinding short circuited due to a null-conditional
                parent,         // any - only null or undefined if short circuited due to a null-conditional
                propertyName,   // any
                target,         // any
            };
        }
    }
    var blazorJSInterop = new BlazorJSInterop();
    globalThis.blazorJSInterop = blazorJSInterop;
    DotNet.attachReviver(function (key, value) {
        if (value && typeof value === 'object') {
            if ('_callbackId' in value) {
                var _callbackId = value._callbackId;
                var callback = blazorJSInterop.callbacks[_callbackId];
                if (callback) return callback;
                callback = function fn() {
                    if (callback !== blazorJSInterop.callbacks[_callbackId]) {
                        console.warn('Disposed callback called.');
                        return;
                    }
                    var ret = null;
                    var args = ["Invoke"];
                    var paramTypes = value._paramTypes;
                    for (var i = 0; i < paramTypes.length; i++) {
                        var v = i < arguments.length ? arguments[i] : null;
                        var jsCallResultType = paramTypes[i];
                        v = blazorJSInterop.serializeToDotNet(v, jsCallResultType);
                        args.push(v);
                    }
                    try {
                        ret = value._callback.invokeMethod.apply(value._callback, args);
                        if (!value._returnVoid) return ret;
                    } catch (ex) {
                        console.error('Callback invokeMethod error:', args, ret, ex);
                    }
                };
                blazorJSInterop.callbacks[_callbackId] = callback;
                return callback;
            }
            else if ('_callbackAsyncId' in value) {
                var _callbackId = value._callbackAsyncId;
                var callback = blazorJSInterop.asyncCallbacks[_callbackId];
                if (callback) return callback;
                callback = function fn() {
                    if (callback !== blazorJSInterop.asyncCallbacks[_callbackId]) {
                        console.warn('Disposed callback called.');
                        return;
                    }
                    var ret = null;
                    var args = ["InvokeAsync"];
                    var paramTypes = value._paramTypes;
                    for (var i = 0; i < paramTypes.length; i++) {
                        var v = i < arguments.length ? arguments[i] : null;
                        var jsCallResultType = paramTypes[i];
                        v = blazorJSInterop.serializeToDotNet(v, jsCallResultType);
                        args.push(v);
                    }
                    try {
                        // call async invoke
                        ret = value._callback.invokeMethodAsync.apply(value._callback, args);
                        if (!value._returnVoid) return ret;
                    } catch (ex) {
                        console.error('Callback invokeMethod error:', args, ret, ex);
                    }
                };
                blazorJSInterop.asyncCallbacks[_callbackId] = callback;
                return callback;
            }
            else if ('__wrappedJSObject' in value) {
                return value.__wrappedJSObject;
            }
            else if ('__undefinedref__' in value) {
                return;
            }
            else if ('$bigint' in value) {
                return BigInt(value.$bigint);
            }
        }
        return value;
    });
    // Below code adds support for serializing BigInt
    // https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/BigInt#use_within_json
    BigInt.prototype.toJSON = function () {
        return { $bigint: this.toString() };
    };
})()