using SpawnDev.BlazorJS.Test.Services;

namespace SpawnDev.BlazorJS.Test.UnitTests {
    public class Examples {

        [TestMethod]
        public void NotImplementedTest() {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void ThreadSleepTest() {
            Thread.Sleep(5000);
        }

        [TestMethod]
        public async Task TaskDelayTest() {
            await Task.Delay(5000);
        }
    }
}
