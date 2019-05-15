namespace IntTest.Hooks
{
    using NUnit.Framework;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    [TestFixture]
    public static class TestRunContext
    {
        public static IWebDriver Driver { get; set; }

        public static void SetupChromeDriver()
        {
            Driver = new ChromeDriver();
            Driver.Navigate().GoToUrl("https://www.google.co.uk");
        }
    }
}
