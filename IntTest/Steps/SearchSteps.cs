using System;
using IntTest.Models;
using IntTest.Models.Enums;
using IntTest.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace IntTest.Steps
{
    [Binding]
    class SearchSteps : PageBase
    {
        private SearchResultsPage _searchResultsPage { get; }

        public SearchSteps(PageContext context, SearchResultsPage searchResultsPage)
            : base(context)
        {
            _searchResultsPage = searchResultsPage;
        }

        [When(@"I perform a search with (.*), (.*), (.*)")]
        public void PerformASearchWith(string keyword, string location, string radius)
        {

            int radiusVal;

            radiusVal = radius.Equals(string.Empty) ? 10 : int.Parse(radius);

            Radius? radiusEnum = (Radius)Enum.Parse(typeof(Radius), radiusVal.ToString());

            Search search = new Search()
            {
                Keyword = keyword,
                Location = location,
                Radius = radiusEnum
            };

            _searchResultsPage.Search(search);
        }

        [Then(@"the results page should be present")]
        public void ResultsPagePresent()
        {
            Assert.True(_searchResultsPage.IsPresent());
        }
    }
}
