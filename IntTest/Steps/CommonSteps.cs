using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntTest.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace IntTest.Steps
{
    [Binding]
    class CommonSteps : PageBase
    {
        public CommonSteps(PageContext context)
            : base(context)
        {
            
        }
        [Given(@"I am on the TotalJobs search results page")]
        public void GivenIAmOnTheTotalJobsSearchResultsPage()
        {
            string navigationUrl = "https://www.totaljobs.com/jobs";

            this.NavigateToUrl(navigationUrl);

            string currentUrl = this.GetPageUrl();

            Assert.AreEqual(navigationUrl, currentUrl);
        }
    }
}
