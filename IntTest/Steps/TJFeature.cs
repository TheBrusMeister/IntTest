namespace IntTest.Steps
{
    using Pages;
    using NUnit.Framework;
    using TechTalk.SpecFlow;

    [Binding]
    class TJFeature : PageBase
    {

        private TJHomePage TJHomePage { get; }

        public TJFeature(PageContext context, TJHomePage tjHomePage)
            :base(context)
        {
            this.TJHomePage = tjHomePage;
        }

        [Given(@"I am on the Total Jobs homepage")]
        public void GivenIAmOnTheTotalJobsHomepage()
        {
            string navigationUrl = "https://www.totaljobs.com/";

            this.NavigateToUrl(navigationUrl);

            string currentUrl = this.GetPageUrl();

            Assert.AreEqual(navigationUrl, currentUrl);
        }

        [When(@"I make a search with details (.*), (.*), (.*)")]
        public void WhenIMakeASearchWithDetails(string role, string location, string radius)
        {
            this.ClearAndEnterTextId(TJHomePage.IdAttribute.positionTxt, role);
            this.ClearAndEnterTextId(TJHomePage.IdAttribute.locationTxt, location);
            this.SelectTextFromDropdown(TJHomePage.IdAttribute.distanceDdl, radius);
            
        }

        [When(@"I add additional criteria (.*), (.*), (.*), (.*)")]
        public void WhenIAddAdditionalCriteria(string salary, string salaryAmount, string jobType, string recruiterType)
        {
            this.TJHomePage.MoreOptions(salary, salaryAmount, jobType, recruiterType);
        }

        [When(@"I click the search button")]
        public void WhenIClickTheSearchButton()
        {
            this.ClickButton(TJHomePage.IdAttribute.searchBtn);
        }

        [Then(@"I am shown job results (.*)")]
        public void ThenIAmShownJobResults(string expectedUrl)
        {
            string currentUrl = this.GetPageUrl();

            Assert.AreEqual(expectedUrl, currentUrl);
        }

    }
}
