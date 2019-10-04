using System;
using IntTest.Models;
using IntTest.Models.Enums;
using IntTest.Pages;
using TechTalk.SpecFlow;

namespace IntTest.Steps
{
    [Binding]
    class RefineSearchSteps : PageBase
    {
        private SearchResultsPage _searchResultsPage { get; }

        public RefineSearchSteps(PageContext context, SearchResultsPage searchResultsPage)
            : base(context)
        {
            _searchResultsPage = searchResultsPage;
        }

        [When(@"I perform a search via refine search with (.*), (.*), (.*)")]
        public void PerformARefineSearch(string keyword, string location, string radius)
        {
            int? radiusVal;

            if (radius.Equals(string.Empty))
            {
                radiusVal = null;
            }
            else
            {
                radiusVal = int.Parse(radius);
            }

            Radius? radiusEnum = null;

            if(radiusVal != null)
            {
                var i = (int) radiusVal; 
                radiusEnum = (Radius) Enum.Parse(typeof(Radius), i.ToString());
            }

            
            Search search = new Search()
            {
                Keyword = keyword,
                Location =  location,
                Radius = radiusEnum,
                SearchType = SearchType.Refine
            };

            _searchResultsPage.Search(search);
        }
    }
}
