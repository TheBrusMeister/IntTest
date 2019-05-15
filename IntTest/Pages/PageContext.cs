using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

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
