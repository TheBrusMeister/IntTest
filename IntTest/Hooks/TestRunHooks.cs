namespace IntTest.Hooks
{
    using System.Threading.Tasks;

    using TechTalk.SpecFlow;

    [Binding]
    internal static class TestRunHooks
    {
        [BeforeTestRun]
        public static void BeforeRun()
        {
            TestRunContext.SetupChromeDriver();
        }

        [AfterTestRun]
        public static void AfterRun()
        {
            TestRunContext.Driver.Quit();
        }
    }
}
