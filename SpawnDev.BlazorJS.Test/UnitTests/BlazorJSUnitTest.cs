using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using Radzen.Blazor;
using SpawnDev.Blazor.UnitTesting;
using SpawnDev.BlazorJS.JSObjects;
using SpawnDev.BlazorJS.JsonConverters;
using SpawnDev.BlazorJS.Test;
using SpawnDev.BlazorJS.Test.Services;
using File = SpawnDev.BlazorJS.JSObjects.File;

namespace SpawnDev.BlazorJS.Test.UnitTests
{
    [TestClass]
    public class BlazorJSUnitTest
    {
        BlazorJSRuntime JS;
        public BlazorJSUnitTest()
        {
            JS = BlazorJSRuntime.JS;
        }

        [TestMethod]
        public void IJSInProcessObjectReferenceCallbackArgTest()
        {
            using var w = JS.Get<Window>("window");
            var testName = Guid.NewGuid().ToString();
            w.Name = testName;
            using var testAction = Callback.CreateOne((IJSInProcessObjectReference val) =>
            {
                var readName = val.Get<string>("name");
                if (readName != testName) throw new Exception("Unexpected result");
            });
            JS.Set("_actionCallback", testAction);
            // read back in our Action as a Javascript Function reference and call it
            var fn = JS.Get<Function>("_actionCallback");
            fn.CallVoid(null, w);
        }

        [TestMethod]
        public void JSObjectReferenceCallbackArgTest()
        {
            using var w = JS.Get<Window>("window");
            var testName = Guid.NewGuid().ToString();
            w.Name = testName;
            using var testAction = Callback.CreateOne((Window val) =>
            {
                var readName = val.Name;
                if (readName != testName) throw new Exception("Unexpected result");
            });
            JS.Set("_actionCallback", testAction);
            // read back in our Action as a Javascript Function reference and call it
            var fn = JS.Get<Function>("_actionCallback");
            fn.CallVoid(null, w);
        }

        [TestMethod]
        public void ActionConverterSerializationTest()
        {
            int testValue = 42;
            var testAction = new Action<int>((val) =>
            {
                if (val != testValue) throw new Exception("Unexpected result");
                Console.WriteLine($"Callback called: {val}");
            });
            // set a global Javascript var to our Action<int>
            // if this is the first time this action is passed to Javascript a Callback will be created and associated to this Action for use in future serialization
            // the auto created Callback must be disposed by calling the extension method Action.DisposeJS()
            JS.Set("_actionCallback", testAction);
            // read back in our Action as a Javascript Function reference and call it
            var fn = JS.Get<Function>("_actionCallback");
            fn.CallVoid(null, testValue);
            // console output: Callback called: 42
            // dispose the Callback associated with this Action
            testAction.DisposeJS();
        }

        [TestMethod]
        public async Task ActionSetTimeoutTest()
        {
            var tcs = new TaskCompletionSource<bool>();
            var callback = () =>
            {
                tcs.TrySetResult(true);
            };
            JS.CallVoid("setTimeout", callback, 100);
            await tcs.Task;
            callback.DisposeJS();
        }

        [TestMethod]
        public async Task ActionConverterTest()
        {
            int testValue = 42;
            var origAction = new Action<int>((val) =>
            {
                if (val != testValue) throw new Exception("Unexpected result");
                Console.WriteLine($"Callback called: {val}");
            });
            // set a global Javascript var to our Action<int>
            // if this is the first time this Action is passed to Javascript a Callback will be created and associated to this Action for use in future serialization
            // the auto created Callback must be disposed by calling the extension method Action.DisposeJS()
            JS.Set("_actionCallback", origAction);
            // read back in our Action as an Action 
            // internally a Javascript Function reference is created and associated with this Action.
            // the auto created Function must be disposed by calling the extension method Action.DisposeJS()
            var readAction = JS.Get<Action<int>>("_actionCallback");
            readAction(testValue);
            // console output: Callback called: 42
            // dispose the Function created and associated with the read Action
            readAction.DisposeJS();
            // dispose the Callback created and associated with the original Action
            origAction.DisposeJS();
        }

        [TestMethod]
        public void FuncConverterTest()
        {
            int testValue = 42;
            var origFunc = new Func<int, int>((val) =>
            {
                return val;
            });
            // set a global Javascript var to our Func<int>
            // if this is the first time this Func is passed to Javascript a Callback will be created and associated to this Func for use in future serialization
            // the auto created Callback must be disposed by calling the extension method Func.DisposeJS()
            JS.Set("_funcCallback", origFunc);
            // read back in our Func as a Func 
            // internally a Javascript Function reference is created and associated with this Func.
            // the auto created Function must be disposed by calling the extension method Func.DisposeJS()
            var readFunc = JS.Get<Func<int, int>>("_funcCallback");
            var readVal = readFunc(testValue);
            if (readVal != testValue) throw new Exception("Unexpected result");
            // dispose the Function created and associated with the read Func
            readFunc.DisposeJS();
            // dispose the Callback created and associated with the original Func
            origFunc.DisposeJS();
        }

        [TestMethod]
        public void UnionTypeTest()
        {
            void UnionTypeTestMethod(string varName, Union<bool?, string?> unionTypeValue)
            {
                JS.Set(varName, unionTypeValue);
            }

            string stringValue = "Hello world!";
            UnionTypeTestMethod("_stringUnionValue", stringValue);
            if (stringValue != JS.Get<string?>("_stringUnionValue")) throw new Exception("Unexpected result");

            bool boolValue = true;
            UnionTypeTestMethod("_boolUnionValue", boolValue);
            if (boolValue != JS.Get<bool?>("_boolUnionValue")) throw new Exception("Unexpected result");
        }

        /// <summary>
        /// Uses File to test an IEnumerable Union type<br />
        /// Creates a new File instance using a string and a blob
        /// </summary>
        /// <exception cref="Exception"></exception>
        [TestMethod]
        public async Task UnionTypeArrayTest()
        {
            var fullString = "Hello World!";
            var strPart1 = fullString.Substring(0, fullString.IndexOf(" "));
            var strPart2 = fullString.Substring(fullString.IndexOf(" "));
            using var blob = new Blob(new string[] { strPart2 });
            using var file = new File([ strPart1, blob ], "filename.txt");
            var txt = await file.Text();
            if (txt != fullString) throw new Exception("Unexpected result");
        }


        [TestMethod]
        public void UnionNullTypeTest()
        {
            void UnionTypeTestMethod(string varName, Union<bool?, string?> unionTypeValue)
            {
                JS.Set(varName, unionTypeValue);
            }

            bool? nullableBoolValue = null;
            UnionTypeTestMethod("_boolUnionValue", nullableBoolValue);
            if (nullableBoolValue != JS.Get<bool?>("_boolUnionValue")) throw new Exception("Unexpected result");
        }

        /// <summary>
        /// Demonstrates using Undefinable with a Union type
        /// </summary>
        /// <exception cref="Exception"></exception>
        [TestMethod]
        public void UnionTypeWithUndefinedOptionTest()
        {
            void UnionTypeTestMethod(string varName, Union<bool?, string?, Undefinable?> unionTypeValue)
            {
                JS.Set(varName, unionTypeValue);
            }

            UnionTypeTestMethod("_unionValue", Undefinable.Undefined);
            if (!JS.IsUndefined("_unionValue")) throw new Exception("Unexpected result");

            bool? nullableBoolValue = null;
            UnionTypeTestMethod("_boolUnionValue", nullableBoolValue);
            if (nullableBoolValue != JS.Get<bool?>("_boolUnionValue")) throw new Exception("Unexpected result");

        }

        // IJSObject
        public interface IWindow : IJSObject
        {
            string Name { get; set; }
        }

        [TestMethod]
        public void GetUndefinedVarReturnsDefaultInt()
        {
            var w = JS.Get<int>("_somethingThatDoesNotExist");
            if (w != default) throw new Exception("Unexpected result");
        }

        [TestMethod]
        public void GetUndefinedVarReturnsDefaultNullable()
        {
            var w = JS.Get<int?>("_somethingThatDoesNotExist");
            if (w != default) throw new Exception("Unexpected result");
        }

        [TestMethod]
        public void IJSObjectInterfacePropertySetGet()
        {
            var w = JS.Get<IWindow>("window");
            var randName = Guid.NewGuid().ToString();
            w.Name = randName;
            if (w.Name != randName) throw new Exception("Interface property set/get failed");
        }

        [TestMethod]
        public void IJSObjectInterfaceNullSetGet()
        {
            IWindow? w = null;
            JS.Set("_nullinterface", w);
            w = JS.Get<IWindow?>("_nullinterface");
            if (w != null) throw new Exception("Unexpected result");
        }

        [TestMethod]
        public void IJSObjectInterfaceArraySetGet()
        {
            var w = JS.Get<IWindow>("window");
            var randName = Guid.NewGuid().ToString();
            w.Name = randName;
            var array = new IWindow[] { w, w, w };
            JS.Set("_array", array);
            var arrayReadBack = JS.Get<IWindow[]>("_array");
            if (arrayReadBack.ToList().Where(w => w.Name != randName).Any()) throw new Exception("Interface array set/get failed");
        }

        // JSObject
        [TestMethod]
        public void JSObjectPropertySetGet()
        {
            var w = JS.Get<Window>("window");
            var randName = Guid.NewGuid().ToString();
            w.Name = randName;
            if (w.Name != randName) throw new Exception("Interface property set/get failed");
        }

        [TestMethod]
        public void JSObjectArraySetGet()
        {
            var w = JS.Get<Window>("window");
            var randName = Guid.NewGuid().ToString();
            w.Name = randName;
            var array = new Window[] { w, w, w };
            JS.Set("_array", array);
            var arrayReadBack = JS.Get<Window[]>("_array");
            if (arrayReadBack.ToList().Where(w => w.Name != randName).Any()) throw new Exception("Interface array set/get failed");
        }

        [TestMethod]
        public async Task PromiseFromErroredTask()
        {
            using var promise = new Promise(Task.FromException(new Exception("Faulted promise")));
            try
            {
                await promise.ThenAsync();
                throw new Exception("Promise should have caused an exception");
            }
            catch
            { }
        }

        [TestMethod]
        public async Task PromiseFromCompletedTask()
        {
            var randValue = Guid.NewGuid().ToString();
            using var promise = new Promise<string>(Task.FromResult(randValue));
            var returnedValue = await promise.ThenAsync();
            if (returnedValue != randValue) throw new Exception("Promise return value mismatch");
        }

        [TestMethod]
        public async Task JSObjectPromiseFromTask()
        {
            var randValue = Guid.NewGuid().ToString();
            var tcs = new TaskCompletionSource<string>();
            using var promise = new Promise<string>(tcs.Task);
            Async.Run(async () =>
            {
                await Task.Delay(1);
                tcs.TrySetResult(randValue);
            });
            var returnedValue = await promise.ThenAsync();
            if (returnedValue != randValue) throw new Exception("Promise return value mismatch");
        }

        [TestMethod]
        public async Task JSObjectPromiseFromLambda()
        {
            var randValue = Guid.NewGuid().ToString();
            var tcs = new TaskCompletionSource<string>();
            using var promise = new Promise<string>(async () =>
            {
                await Task.Delay(1);
                return randValue;
            });
            var returnedValue = await promise.ThenAsync();
            if (returnedValue != randValue) throw new Exception("Promise return value mismatch");
        }

        [TestMethod]
        public async Task JSObjectPromiseRejectVoid()
        {
            var randValue = Guid.NewGuid().ToString();
            using var promise = new Promise(async () =>
            {
                await Task.Delay(1);
                throw new Exception();
            });
            try
            {
                await promise.ThenAsync();
                throw new Exception("Promise should have caused an exception");
            }
            catch
            { }
        }

        [TestMethod]
        public async Task JSObjectPromiseFromTaskVoid()
        {
            var randValue = Guid.NewGuid().ToString();
            var tcs = new TaskCompletionSource();
            using var promise = new Promise(tcs.Task);
            Async.Run(async () =>
            {
                await Task.Delay(1);
                tcs.TrySetResult();
            });
            await promise.ThenAsync();
        }

        [TestMethod]
        public async Task JSObjectPromiseFromLambdaVoid()
        {
            var randValue = Guid.NewGuid().ToString();
            var tcs = new TaskCompletionSource();
            using var promise = new Promise(async () =>
            {
                await Task.Delay(1);
            });
            await promise.ThenAsync();
        }

        [TestMethod]
        public void JSObjectUndefinedTest()
        {
            // Get an instance of the Window JSObject class that is revived in Javascript as undefined
            var undefinedWindow = JSObject<Window>.Undefined;
            JS.Set("_undefinedWindow", undefinedWindow);
            var isUndefined = JS.IsUndefined("_undefinedWindow");
            // isUndefined == true here
            if (!isUndefined) throw new Exception("Unexpected result");
        }

        [TestMethod]
        public void UndefinableTestInt()
        {
            // an example method that parameters that may take undefined as values
            void MethodWithUndefinableParams(string varName, Undefinable<int?>? window)
            {
                JS.Set(varName, window);
            }

            int? w = 5;
            // test to show the value is passed normally
            MethodWithUndefinableParams("_willBeDefined1", w);
            int? r = JS.Get<int?>("_willBeDefined1");
            if (r != w) throw new Exception("Unexpected result");

            w = null;
            // null defaults to passing as undefined
            MethodWithUndefinableParams("_willBeUndefined1", w);
            if (!JS.IsUndefined("_willBeUndefined1")) throw new Exception("Unexpected result");

            // if you need to pass null to an Undefinable parameter use Undefinable<T?>.Null
            MethodWithUndefinableParams("_willBeNull1", Undefinable<int?>.Null);
            if (JS.IsUndefined("_willBeNull1")) throw new Exception("Unexpected result");

            // another way to pass undefined
            MethodWithUndefinableParams("_willAlsoBeUndefined1", Undefinable<int?>.Undefined);
            if (!JS.IsUndefined("_willAlsoBeUndefined1")) throw new Exception("Unexpected result");
        }

        [TestMethod]
        public void UndefinableTestBool()
        {
            // an example method with a parameter that can also be null or undefined
            // T of Undefinable<T> must be nullable
            void MethodWithUndefinableParams(string varName, Undefinable<bool?>? window)
            {
                JS.Set(varName, window);
            }

            bool? w = false;
            // test to show the value is passed normally
            MethodWithUndefinableParams("_willBeDefined2", w);
            bool? r = JS.Get<bool?>("_willBeDefined2");
            if (r != w) throw new Exception("Unexpected result");

            w = null;
            // null defaults to passing as undefined
            MethodWithUndefinableParams("_willBeUndefined2", w);
            if (!JS.IsUndefined("_willBeUndefined2")) throw new Exception("Unexpected result");

            // if you need to pass null to an Undefinable parameter use Undefinable<T?>.Null
            MethodWithUndefinableParams("_willBeNull2", Undefinable<bool?>.Null);
            if (JS.IsUndefined("_willBeNull2")) throw new Exception("Unexpected result");

            // another way to pass undefined
            MethodWithUndefinableParams("_willAlsoBeUndefined2", Undefinable<bool?>.Undefined);
            if (!JS.IsUndefined("_willAlsoBeUndefined2")) throw new Exception("Unexpected result");
        }
    }
}
