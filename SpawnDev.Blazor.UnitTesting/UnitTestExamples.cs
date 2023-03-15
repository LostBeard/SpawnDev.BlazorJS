
namespace SpawnDev.Blazor.UnitTesting {
    [TestClass]
    public class UnitTestExamples {

        [TestMethod]
        public void NotImplementedTest() {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void ThreadSleepTest() {
            Thread.Sleep(1000);
        }

        [TestMethod]
        public async Task TaskDelayTest() {
            await Task.Delay(1000);
        }

        [TestMethod]
        public string ReturnAdditionalFailureInfo()
        {
            throw new Exception("Additional error info");
        }

        [TestMethod]
        public string ReturnValueTest()
        {
            return "Additional success info";
        }

        [TestMethod]
        public async Task<string> ReturnValueTestAsync()
        {
            await Task.Delay(1);
            return "Additional success info";
        }
    }
}
