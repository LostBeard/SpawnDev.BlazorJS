using SpawnDev.Blazor.UnitTesting;
using SpawnDev.BlazorJS.JSObjects;
using System.Linq.Expressions;

namespace SpawnDev.BlazorJS.Test.UnitTests
{
    [TestClass]
    public class BlazorJSUnitTest
    {

        [TestMethod]
        public void UnionTypeTest()
        {
            void UnionTypeTestMethod(string varName, Union<bool?, string?>? unionTypeValue)
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

        // Promise
        [TestMethod]
        public async Task JSObjectPromiseResolve()
        {
            var randValue = Guid.NewGuid().ToString();
            using var promise = new Promise<string>();
            _ = Task.Run(async () =>
            {
                await Task.Delay(1);
                promise.Resolve(randValue);
            });
            var returnedValue = await promise.ThenAsync();
            if (returnedValue != randValue) throw new Exception("Promise return value mismatch");
        }

        [TestMethod]
        public async Task JSObjectPromiseFromTask()
        {
            var randValue = Guid.NewGuid().ToString();
            var tcs = new TaskCompletionSource<string>();
            using var promise = new Promise<string>(tcs.Task);
            _ = Task.Run(async () =>
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
        public async Task JSObjectPromiseResolveVoid()
        {
            var randValue = Guid.NewGuid().ToString();
            using var promise = new Promise();
            _ = Task.Run(async () =>
            {
                await Task.Delay(1);
                promise.Resolve(randValue);
            });
            await promise.ThenAsync();
        }

        [TestMethod]
        public async Task JSObjectPromiseRejectVoid()
        {
            var randValue = Guid.NewGuid().ToString();
            using var promise = new Promise();
            _ = Task.Run(async () =>
            {
                await Task.Delay(1);
                promise.Reject();
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
            _ = Task.Run(async () =>
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
