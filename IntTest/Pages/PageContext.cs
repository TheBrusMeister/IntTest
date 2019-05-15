using OpenQA.Selenium;

namespace IntTest.Pages
{
    class PageContext
    {
        public PageContext(IWebDriver driver)
        {
            this.Driver = driver;
        }

        public IWebDriver Driver { get; set; }
    }
}
