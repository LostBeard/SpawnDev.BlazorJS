namespace PlaywrightTestRunner
{
    [SetUpFixture]
    public class GlobalSetup
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            // This tells Playwright to run in headed mode for the entire test run
            //Environment.SetEnvironmentVariable("HEADED", "1");
            // The fake media flags live in playwright.runsettings (LaunchOptions.Args): Microsoft.Playwright.NUnit
            // never read a PLAYWRIGHT_ARGS environment variable, so setting one here launched Chromium without them.
        }
    }
}
