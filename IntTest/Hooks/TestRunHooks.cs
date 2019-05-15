namespace IntTest.Hooks
{
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
