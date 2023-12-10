namespace SpawnDev.BlazorJS.Reflection
{
    public interface IAsyncCallDispatcherTest
    {
        string IITestProp1 { get; set; }
        Task<string> IITestProp2 { get; set; }
        ValueTask<string> IITestProp3 { get; set; }
        Task IITestProp4 { get; set; }
        ValueTask IITestProp5 { get; set; }
        void IITest1();
        string IITest2(string data);
        Task<string> IITest3();
        ValueTask<string> IITest4();
        Task IITest5();
        ValueTask IITest6();
        Task Test(AsyncCallDispatcher? caller = null);
    }
    public class AsyncCallDispatcherTest : IAsyncCallDispatcherTest
    {
        public static string Context => BlazorJSRuntime.JS.GlobalThisTypeName;
        public static string TestProp1 { get; set; } = $"TestProp1 here {Context}";
        public static Task<string> TestProp2 { get; set; } = Task.FromResult($"TestProp2 here {Context}");
        public static ValueTask<string> TestProp3 { get; set; } = ValueTask.FromResult($"TestProp3 here {Context}");
        public static Task TestProp4 { get; set; } = Task.CompletedTask;
        public static ValueTask TestProp5 { get; set; } = ValueTask.CompletedTask;
        public static void Test1()
        {
            Console.WriteLine($"Test1 {Context}");
        }
        public static string Test2(string data)
        {
            Console.WriteLine($"Test2: {data} {Context}");
            return $"Test2 {data} {Context}";
        }
        public static async Task<string> Test3()
        {
            Console.WriteLine($"Test3 {Context}");
            return $"Test3 here {Context}";
        }
        public static async ValueTask<string> Test4()
        {
            Console.WriteLine($"Test4 {Context}");
            return $"Test4 here {Context}";
        }
        public static async Task Test5()
        {
            Console.WriteLine($"Test5 {Context}");
        }
        public static async ValueTask Test6()
        {
            Console.WriteLine($"Test6 {Context}");
        }

        public string IITestProp1 { get; set; } = $"IITestProp1 here {Context}";
        public Task<string> IITestProp2 { get; set; } = Task.FromResult($"IITestProp2 here {Context}");
        public ValueTask<string> IITestProp3 { get; set; } = ValueTask.FromResult($"IITestProp3 here {Context}");
        public Task IITestProp4 { get; set; } = Task.CompletedTask;
        public ValueTask IITestProp5 { get; set; } = ValueTask.CompletedTask;
        public void IITest1()
        {
            Console.WriteLine($"IITest1 {Context}");
        }
        public string IITest2(string data)
        {
            Console.WriteLine($"IITest2: {data} {Context}");
            return $"IITest2 {data} {Context}";
        }
        public async Task<string> IITest3()
        {
            Console.WriteLine($"IITest3 {Context}");
            return $"IITest3 here {Context}";
        }
        public async ValueTask<string> IITest4()
        {
            Console.WriteLine($"IITest4 {Context}");
            return $"IITest4 here {Context}";
        }
        public async Task IITest5()
        {
            Console.WriteLine($"IITest5 {Context}");
        }
        public async ValueTask IITest6()
        {
            Console.WriteLine($"IITest6 {Context}");
        }

        public async Task Test(AsyncCallDispatcher? caller = null)
        {
            var JS = BlazorJSRuntime.JS;
            caller = caller ?? new AsyncCallDispatcher();
            // Expressions
            // static property get
            Console.WriteLine("Expression static properties get");
            JS.Log($"{Context} " + await caller.Run(() => TestProp1));
            JS.Log($"{Context} " + await caller.Run(() => TestProp2));
            JS.Log($"{Context} " + await caller.Run(() => TestProp3));
            await caller.Run(() => TestProp4);
            await caller.Run(() => TestProp5);
            // static property set
            Console.WriteLine("Expression static properties set");
            await caller.Set(() => TestProp1, "Yay!");
            // static methods
            Console.WriteLine("Expression static methods");
            await caller.Run(() => Test1());
            JS.Log($"{Context} " + await caller.Run(() => Test2("Hello!!")));
            JS.Log($"{Context} " + await caller.Run(() => Test3()));
            JS.Log($"{Context} " + await caller.Run(() => Test4()));

            JS.Log($"{Context} " + await caller.Run(() => IITest4()));
            await caller.Run(() => Test5());
            await caller.Run(() => Test6());
            // instance property get
            Console.WriteLine("Expression instance properties get");
            JS.Log($"{Context} " + await caller.Run<AsyncCallDispatcherTest, string>(s => s.IITestProp1));
            JS.Log($"{Context} " + await caller.Run<AsyncCallDispatcherTest, string>(s => s.IITestProp2));
            JS.Log($"{Context} " + await caller.Run<AsyncCallDispatcherTest, string>(s => s.IITestProp3));
            await caller.Run<AsyncCallDispatcherTest>(s => s.IITestProp4);
            await caller.Run<AsyncCallDispatcherTest>(s => s.IITestProp5);
            // instance property set
            Console.WriteLine("Expression instance properties set");
            await caller.Set<AsyncCallDispatcherTest, string>(s => s.IITestProp1, "Yay!");
            // instance methods
            Console.WriteLine("Expression instance methods");
            await caller.Run<AsyncCallDispatcherTest>(s => s.IITest1());
            JS.Log($"{Context} " + await caller.Run<AsyncCallDispatcherTest, string>(s => s.IITest2("Hello!!")));
            JS.Log($"{Context} " + await caller.Run<AsyncCallDispatcherTest, string>(s => s.IITest3()));
            JS.Log($"{Context} " + await caller.Run<AsyncCallDispatcherTest, string>(s => s.IITest4()));
            await caller.Run<AsyncCallDispatcherTest>(s => s.IITest5());
            await caller.Run<AsyncCallDispatcherTest>(s => s.IITest6());

            // Delegates
            // static methods
            Console.WriteLine("Delegate static methods");
            await caller.Invoke(Test1);
            JS.Log($"{Context} " + caller.Invoke(Test2, "Grapes rock"));
            JS.Log($"{Context} " + await caller.Invoke(Test3));
            JS.Log($"{Context} " + caller.Invoke(Test4));
            await caller.Invoke(Test5);
            await caller.Invoke(Test6);
            // instance methods
            Console.WriteLine("Delegate instance methods");
            await caller.Invoke(IITest1);
            JS.Log($"{Context} " + await caller.Invoke(IITest2, "Grapes rock"));
            JS.Log($"{Context} " + await caller.Invoke(IITest3));
            JS.Log($"{Context} " + await caller.Invoke(IITest4));
            await caller.Invoke(IITest5);
            await caller.Invoke(IITest6);
            Console.WriteLine("***** Test Done *****");

            //// Lambdas do not work
            //await caller.Invoke((data) =>
            //{
            //    Console.WriteLine($"Lambda here!! data: {data}");
            //    return "ok";
            //}, "wtf");
            //Console.WriteLine("***** Test 1 *****");
        }
    }
}
