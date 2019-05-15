namespace IntTest.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Support.UI;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Tracing;

    using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
    using TestContext = NUnit.Framework.TestContext;

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

        public void ClearAndEnterText(string criteria, string value)
        {
            this.Context.Driver.FindElement(By.Id(criteria)).Clear();
            this.Context.Driver.FindElement(By.Id(criteria)).SendKeys(value);
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

        public void WaitForElementToBeClickable(string criteria, int time = 10)
        {
            var wait = new WebDriverWait(this.Context.Driver, TimeSpan.FromSeconds(time));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(criteria)));
        }
    }
}
