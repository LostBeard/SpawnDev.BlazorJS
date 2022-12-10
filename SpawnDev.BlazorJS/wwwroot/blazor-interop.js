//'use strict';

//// get the globalThis instance
//// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/globalThis
//function check(it) {
//    // Math is known to exist as a global in every environment.
//    return it && it.Math === Math && it;
//}

//const globalObject =
//    check(typeof window === 'object' && window) ||
//    check(typeof self === 'object' && self) ||
//    check(typeof global === 'object' && global) ||
//    check(typeof globalThis === 'object' && globalThis) ||
//    // This returns undefined when running in strict mode
//    (function () { return this; })() ||
//    Function('return this')();

//var initFunc = function () {
//    if (globalObject.JSInterop) return;
//    const JSInterop = {};
//    globalObject.JSInterop = JSInterop;

//    JSInterop.pathObjectInfo = function (rootObject, path) {
//        var parent = rootObject ?? globalObject;
//        var target;
//        var propertyName = null;
//        if (typeof path === 'string' && path.length) {
//            if (path === 'Symbol.asyncIterator' && parent !== null) {
//                // get the async iterator
//                target = parent[Symbol.asyncIterator]();
//            } else {
//                var parts = path.split('.');
//                propertyName = parts[parts.length - 1];
//                for (var i = 0; i < parts.length - 1; i++) {
//                    parent = parent[parts[i]];
//                }
//                target = parent[propertyName];
//            }
//        }
//        else if (typeof path === 'number') {
//            propertyName = path;
//            target = parent[propertyName];
//        } else {
//            target = parent;
//            parent = null;
//        }
//        var targetType = typeof target;
//        var exists = targetType !== 'undefined' || (parent && propertyName && propertyName in parent);
//        return {
//            parent,         // may be null even if target exists (Ex. if no path was given)
//            propertyName,   // may be null even if target exists (Ex. if no path was given)
//            target,         // may be undefined if it does not currently exist
//            targetType,     // will always be a string of the target type (Ex. 'undefined', 'object', 'string', 'number')
//            exists,         // will always be a bool value (true or false)
//        };
//    };

//    JSInterop.pathToTarget = function (rootObject, path) {
//        return JSInterop.pathObjectInfo(rootObject, path).target;
//    };

//    JSInterop.pathToParent = function (rootObject, path) {
//        return JSInterop.pathObjectInfo(rootObject, path).parent;
//    };

//    JSInterop.__equals = function (obj1, obj2) {
//        return obj1 === obj2;
//    }

//    JSInterop._returnMe = function (obj) {
//        return obj;
//    };

//    JSInterop._setProperty = function (obj, name, value) {
//        var pathInfo = JSInterop.pathObjectInfo(obj, name);
//        if (!pathInfo.exists) {
//            console.log('WARNING: JSInterop._setProperty - property being set does not exist', name);
//        }
//        // check if value is a wrapped function, use the the wrapped function as the actual value if it is
//        if (typeof value === 'object' && value !== null && typeof value.__wrappedFunction === 'function') {
//            pathInfo.parent[pathInfo.propertyName] = value.__wrappedFunction;
//        } else {
//            pathInfo.parent[pathInfo.propertyName] = value;
//        }
//    };

//    JSInterop._getPropertyNames = function (obj, name, hasOwnProperty) {
//        var target = JSInterop.pathToTarget(obj, name);
//        var ret = [];
//        for (var k in target) {
//            if (!hasOwnProperty || target.hasOwnProperty(k)) ret.push(k);
//        }
//        return ret;
//    };

//    JSInterop._instanceof = function (obj, name) {
//        var target = JSInterop.pathToTarget(obj, name);
//        return target && target.constructor ? target.constructor.name : '';
//    };

//    JSInterop._typeof = function (obj, name) {
//        var target = JSInterop.pathToTarget(obj, name);
//        return typeof target;
//    };

//    function wrapFunction(fn) {
//        var retRef = {
//            __wrappedFunction: fn,
//            applyFn: function (thisObj, args) {
//                return fn.apply(thisObj, args);
//            }
//        };
//        return retRef;
//    }

//    JSInterop._setMember = function (obj, name, value) {
//        var pathInfo = JSInterop.pathObjectInfo(obj, name);
//        if (!pathInfo.exists) {
//            console.log('WARNING: JSInterop._setProperty - property being set does not exist', name);
//        }
//        // check if value is a wrapped function, use the the wrapped function as the actual value if it is
//        if (typeof value === 'object' && value !== null && typeof value.__wrappedFunction === 'function') {
//            pathInfo.parent[pathInfo.propertyName] = value.__wrappedFunction;
//        } else {
//            pathInfo.parent[pathInfo.propertyName] = value;
//        }
//    };

//    JSInterop._callMember = function (obj, name, args, returnType, returnTypeFinal) {
//        var { target, parent, targetType } = JSInterop.pathObjectInfo(obj, name);
//        if (targetType === "function") {
//            // functions are called with args as the arguments and the return value is what is returned; 
//            // unless returnTypeFinal === 'FunctionHandle' ... then the function is wrapped (to prevent dotnet from refusing it) and the wrapper is returned
//            var fnBound = target.bind(parent);
//            var ret = fnBound.apply(null, args);
//            if (returnType === 'void') {
//                return undefined;
//            } else {
//                return ret;
//            }
//        } else {
//            return null;
//        }
//    };

//    JSInterop._getMember = function (obj, name, args, returnType, returnTypeFinal) {
//        var { target, parent, targetType } = JSInterop.pathObjectInfo(obj, name);
//        if (targetType === "function") {
//            // functions are called with args as the arguments and the return value is what is returned; 
//            // unless returnTypeFinal === 'FunctionHandle' ... then the function is wrapped (to prevent dotnet from refusing it) and the wrapper is returned
//            var fnBound = target.bind(parent);
//            return wrapFunction(fnBound);
//            //var ret = fnBound.apply(null, args);
//            //if (returnType === 'void') {
//            //    return undefined;
//            //} else {
//            //    return ret;
//            //}
//        } else if (targetType === "undefined") {
//            return null;
//        } else {
//            return target;
//        }
//    };

//    JSInterop._getProperty = function (obj, name, args, returnType, returnTypeFinal) {
//        var { target, parent, targetType } = JSInterop.pathObjectInfo(obj, name);
//        if (targetType === "function") {
//            // functions are called with args as the arguments and the return value is what is returned; 
//            // unless returnTypeFinal === 'FunctionHandle' ... then the function is wrapped (to prevent dotnet from refusing it) and the wrapper is returned
//            var fnBound = target.bind(parent);
//            if (returnType === "IJSInProcessObjectReference" && returnTypeFinal === 'FunctionHandle') {
//                return wrapFunction(fnBound);
//            }
//            var ret = fnBound.apply(null, args);
//            if (returnType === 'void') {
//                return undefined;
//            } else {
//                return ret;
//            }
//        } else if (targetType === "undefined") {
//            return null;
//        } else {
//            return target;
//        }
//    };

//    JSInterop._returnNew = function (className, args) {
//        var argsStr = '';
//        if (args && args.length) {
//            var argsCall = [];
//            for (var i = 0; i < args.length; i++) argsCall.push('arguments[0][' + i + ']');
//            argsStr = argsCall.join(', ');
//        }
//        var js = `return new ${className}(${argsStr})`;
//        var fnWrapper = new Function(js);
//        var newInstance = fnWrapper(args);
//        if (className === 'Function') {
//            newInstance = wrapFunction(newInstance);
//        }
//        return newInstance;
//    };

//    JSInterop._runJS = function (js, args) {
//        console.log('DEPRECATED JSInterop._runJS');
//        if (!Array.isArray(args)) args = [];
//        var fn = new Function(js);
//        return fn.apply(globalObject, args);
//    };

//    JSInterop._createFunction = function (js) {
//        console.log('DEPRECATED JSInterop._createFunction');
//        var fnWrapper = {};
//        var fn = new Function(js);
//        fnWrapper.fn = fn;
//        return fnWrapper;
//    };

//    var desrializeNetArgs = false;

//    function deserializeArrayFromDotNet(argsArray) {
//        for (var i = 0; i < argsArray.length; i++) {
//            argsArray[i] = deserializeFromDotNet(argsArray[i]);
//        }
//    }

//    function deserializeFromDotNet(value) {
//        if (typeof value === 'object' && value !== null && typeof value.__wrappedFunction === 'function') {
//            value = value.__wrappedFunction;
//        }
//        return value;
//    }

//    function serializeToDotNet(value, returnType) {
//        if (returnType === 'void') return;
//        var typeOfValue = typeof value;
//        if (typeOfValue === 'undefined') {
//            return null;
//        } else if (typeOfValue === 'function') {
//            return wrapFunction(value);
//        } else {
//            return value;
//        }
//    }

//    // Instance
//    JSInterop._set = function (obj, identifier, value) {
//        if (typeof obj !== 'object' || !obj) throw 'obj null or undefined';
//        var pathInfo = JSInterop.pathObjectInfo(obj, identifier);
//        if (!pathInfo.exists) {
//            console.log('WARNING: JSInterop._setProperty - property being set does not exist', identifier);
//        }
//        if (desrializeNetArgs) {
//            value = deserializeFromDotNet(value);
//        }
//        pathInfo.parent[pathInfo.propertyName] = value;
//    };

//    JSInterop._get = function (obj, identifier, returnType) {
//        var ret = null;
//        if (typeof obj !== 'object' || !obj) throw 'obj null or undefined';
//        var { target, parent, targetType } = JSInterop.pathObjectInfo(obj, identifier);
//        if (targetType === "function") {
//            ret = target.bind(parent);
//        } else {
//            ret = target;
//        }
//        return serializeToDotNet(ret, returnType);
//    };

//    JSInterop._call = function (obj, identifier, args, returnType) {
//        var ret = null;
//        if (typeof obj !== 'object' || !obj) throw 'obj null or undefined';
//        var { target, parent, targetType } = JSInterop.pathObjectInfo(obj, identifier);
//        if (targetType === "function") {
//            var fnBound = target.bind(parent);
//            if (desrializeNetArgs) {
//                deserializeArrayFromDotNet(args);
//            }
//            ret = fnBound.apply(null, args);
//        } else {
//            throw 'Call target is not a function';
//        }
//        return serializeToDotNet(ret, returnType);
//    };

//    JSInterop._callVoid = function (obj, identifier, args) {
//        if (typeof obj !== 'object' || !obj) throw 'obj null or undefined';
//        JSInterop._call(obj, identifier, args);
//    };

//    //Global
//    JSInterop._setGlobal = function (identifier, value) {
//        JSInterop._set(globalObject, identifier, value);
//    };

//    JSInterop._getGlobal = function (identifier, returnType) {
//        return JSInterop._get(globalObject, identifier, returnType);
//    };

//    JSInterop._callGlobal = function (identifier, args, returnType) {
//        return JSInterop._call(globalObject, identifier, args, returnType);
//    };

//    JSInterop._callVoidGlobal = function (identifier, args) {
//        JSInterop._call(globalObject, identifier, args);
//    };


//    // Callback - version 0.91
//    const callbacks = {};
//    JSInterop.DisposeCallbacker = function (callbackerID) {
//        if (callbacks[callbackerID]) delete callbacks[callbackerID];
//    };
//    DotNet.attachReviver(function (key, value) {
//        if (value && typeof value === 'object' && value.hasOwnProperty("__callbackerID")) {
//            let callbackerID = value.__callbackerID;
//            if (!callbacks[callbackerID]) {
//                callbacks[callbackerID] = function fn() {
//                    var ret = null;
//                    if (!callbacks[callbackerID] || fn !== callbacks[callbackerID]) return;
//                    var args = ["Invoke"];
//                    // When the Callback is created the argument types are enumerated so they call be passed back to .Net correctly when the callback is called
//                    // IJSObject - specifies that the argument should be manually passed as a JSObjectReference and it will be wrapped before firing the owner on the other side
//                    // function - specifies the a function that should be wrapped in a fn wrapper
//                    for (var i = 0; i < value.paramTypes.length; i++) {
//                        var v = i < arguments.length ? arguments[i] : null;
//                        var paramType = i < value.paramTypes.length ? value.paramTypes[i] : null;
//                        if (typeof v === 'Function') {
//                            v = wrapFunction(v);
//                        }
//                        if (paramType === 'IJSObject') {
//                            if (typeof v !== 'undefined' && v !== null) {
//                                try {
//                                    v = DotNet.createJSObjectReference(v);
//                                } catch (ex) {
//                                    console.log('WARNING: error calling DotNet.createJSObjectReference on callback argument', ex);
//                                    console.log(value);
//                                }
//                            }
//                        }
//                        args.push(v);
//                    }
//                    try {
//                        ret = value.netObjRef.invokeMethod.apply(value.netObjRef, args);// ('Invoke');
//                        if (typeof value.returnType === 'string' && value.returnType !== '' && value.returnType !== 'Void') {
//                            return ret;
//                        }
//                    } catch (ex) {
//                        if (args && args.length > 0) {
//                            console.log('args[0].constructor.name', args[0].constructor.name);
//                        }
//                        console.log(args);
//                        console.log('callback invokeMethod error:', ret, ex);
//                        console.log('disposing callback');
//                        value.isDisposed = true;
//                    }
//                };
//            }
//            return callbacks[callbackerID];
//        } else {
//            return value;
//        }
//    });
//};

//export function init() {
//    initFunc();
//}