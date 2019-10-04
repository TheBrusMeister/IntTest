using System;
using IntTest.Models;
using IntTest.Models.Enums;
using OpenQA.Selenium;

namespace IntTest.Pages
{
    internal class SearchResultsPage : PageBase
    {
        public SearchResultsPage(PageContext context) : base(context)
        {

        }

        public bool IsPresent()
        {
            return IsPresent(CSSAttribute.ResultsContainer);
        }

        public void Search(Search search)
        {
            int? radiusVal = null;

            if (search.Radius != null)
            {
                radiusVal = (int) search.Radius;
            }

            switch (search.SearchType)
            {
                case SearchType.Header:
                    WaitForElementToBeClickableId(IdAttribute.KeywordInput);
                    ClearAndEnterTextId(IdAttribute.KeywordInput, search.Keyword);
                    ClearAndEnterTextId(IdAttribute.LocationInput, search.Location);
                    SelectValueFromDropdown(IdAttribute.RadiusDropdown, radiusVal.ToString());
                    ClickButton(IdAttribute.SearchButton);
                    break;

                case SearchType.Refine:
                    WaitForElementToBeClickableCSSSelector(CSSAttribute.RefineSearchKeywordInput);

                    //keyword only and default radius
                    if (search.Keyword != string.Empty && search.Location == string.Empty && search.Radius == null)
                    {
                        ClearAndEnterTextCSSSelector(CSSAttribute.RefineSearchKeywordInput, search.Keyword);
                        WaitForElementToBeClickableId(IdAttribute.UpdateKeywordsButton);
                        ClickButton(IdAttribute.UpdateKeywordsButton);
                    }

                    //location only search default radius
                    if (search.Keyword == string.Empty &&  search.Location != string.Empty && search.Radius == null)
                    {
                        ClearAndEnterTextCSSSelector(CSSAttribute.RefineSearchLocationInput, search.Location);
                        WaitForElementToBeClickableId(IdAttribute.UpdateLocationButton);
                        ClickButton(IdAttribute.UpdateLocationButton);
                    }

                    if (search.Keyword != string.Empty && search.Location != string.Empty && search.Radius == null)
                    {
                        ClearAndEnterTextCSSSelector(CSSAttribute.RefineSearchKeywordInput, search.Keyword);
                        ClearAndEnterTextCSSSelector(CSSAttribute.RefineSearchLocationInput, search.Location);
                        WaitForElementToBeClickableId(IdAttribute.UpdateLocationButton);
                        ClickButton(IdAttribute.UpdateLocationButton);
                    }

                    if (search.Location != string.Empty && search.Keyword == string.Empty && search.Radius != null)
                    {
                        //location refine search -- make into function
                        ClearAndEnterTextCSSSelector(CSSAttribute.RefineSearchLocationInput, search.Location);
                        WaitForElementToBeClickableId(IdAttribute.UpdateLocationButton);
                        ClickButton(IdAttribute.UpdateLocationButton);
                        WaitForElementToBeClickableCSSSelector(FormRefineRadiusSelector(radiusVal));
                        ClickRefineSearchRadius(search.Radius);
                    }
                    break;



            }
            
        }

        public void ClickRefineSearchRadius(Radius? radius)
        {
            var radiusVal = (int) radius;
            
            var radiusElement = Context.Driver.FindElement(By.CssSelector(FormRefineRadiusSelector(radiusVal)));

            radiusElement.Click();
        }

        private string FormRefineRadiusSelector(int? val)
        {
            return ".radius-button-group a[title~='" + val + "']";
        }

        internal static class IdAttribute
        {
            public static string KeywordInput => "header-desktop-search-keywords";
            public static string LocationInput => "header-desktop-search-location-text";
            public static string RadiusDropdown => "header-desktop-search-radius";
            public static string SearchButton => "search-submit-button-desktop";
            public static string UpdateKeywordsButton => "btnRefineKeywords";
            public static string UpdateLocationButton => "btnRefineLocation";
        }

        internal static class CSSAttribute
        {
            public static string ResultsContainer => ".job-results";
            public static string RefineSearchKeywordInput => ".refine-keyword-location #keywords";
            public static string RefineSearchLocationInput => ".refine-keyword-location #location";
        }
    }
}
