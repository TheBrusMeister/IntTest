using System.Runtime.Remoting.Contexts;

namespace IntTest.Pages
{
    using System;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

    class PageBase
    {
        protected readonly PageContext Context;

        public PageBase(PageContext context)
        {
            this.Context = context;
            SeleniumExtras.PageObjects.PageFactory.InitElements(this.Context.Driver, this);
        }

        public void NavigateToUrl(string Url)
        {
            this.Context.Driver.Navigate().GoToUrl(Url);
        }

        public string GetPageUrl()
        {
            string Url = this.Context.Driver.Url;

            return Url;
        }

        public string GetPageTitle()
        {
            string title = this.Context.Driver.Title;

            return title;
        }

        public void ClearAndEnterTextId(string criteria, string value)
        {
            this.Context.Driver.FindElement(By.Id(criteria)).Clear();
            this.Context.Driver.FindElement(By.Id(criteria)).SendKeys(value);
        }
        public void ClearAndEnterTextCSSSelector(string criteria, string value)
        {
            this.Context.Driver.FindElement(By.CssSelector(criteria)).Clear();
            this.Context.Driver.FindElement(By.CssSelector(criteria)).SendKeys(value);
        }

        public void ClickButton(string criteria)
        {
            this.Context.Driver.FindElement(By.Id(criteria)).Click();
        }

        public void SelectTextFromDropdown(string criteria, string value)
        {
            var dropdownList = new SelectElement(this.Context.Driver.FindElement(By.Id(criteria)));
            dropdownList.SelectByText(value);
        }

        public void SelectValueFromDropdown(string criteria, string value)
        {
            var dropdownList = new SelectElement(this.Context.Driver.FindElement(By.Id(criteria)));
            dropdownList.SelectByValue(value);
        }

        public void WaitForElementToBeClickableId(string criteria, int time = 10)
        {
            var wait = new WebDriverWait(this.Context.Driver, TimeSpan.FromSeconds(time));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(criteria)));
        }
        public void WaitForElementToBeClickableCSSSelector(string criteria, int time = 10)
        {
            var wait = new WebDriverWait(this.Context.Driver, TimeSpan.FromSeconds(time));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(criteria)));
        }

        public bool IsPresent(string selector)
        {
            var wait = new WebDriverWait(this.Context.Driver, TimeSpan.FromSeconds(10));
            return wait.Until(ExpectedConditions.ElementExists(By.CssSelector(selector))).Displayed;
        }
    }
}
