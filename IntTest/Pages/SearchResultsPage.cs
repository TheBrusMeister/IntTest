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

                    if (search.Keyword != string.Empty && search.Location == string.Empty && search.Radius == null)
                    {
                        KeywordOnlyRefineSearch(search.Keyword);
                    }

                    if (search.Keyword == string.Empty &&  search.Location != string.Empty && search.Radius == null)
                    {
                        LocationRefineSearch(search.Location);
                    }

                    if (search.Keyword != string.Empty && search.Location != string.Empty && search.Radius == null)
                    {
                        KeywordLocationRefineSearch(search.Keyword, search.Location);
                    }

                    if (search.Location != string.Empty && search.Keyword == string.Empty && search.Radius != null)
                    {
                        RefineSearchWithSalary(search.Location, radiusVal, search.Radius);
                    }
                    break;



            }
            
        }

        public void KeywordOnlyRefineSearch(string keyword)
        {
            ClearAndEnterTextCSSSelector(CSSAttribute.RefineSearchKeywordInput, keyword);
            WaitForElementToBeClickableId(IdAttribute.UpdateKeywordsButton);
            ClickButton(IdAttribute.UpdateKeywordsButton);
        }

        private void LocationRefineSearch(string location)
        {
            ClearAndEnterTextCSSSelector(CSSAttribute.RefineSearchLocationInput, location);
            WaitForElementToBeClickableId(IdAttribute.UpdateLocationButton);
            ClickButton(IdAttribute.UpdateLocationButton);
        }

        private void KeywordLocationRefineSearch(string keyword, string location)
        {
            ClearAndEnterTextCSSSelector(CSSAttribute.RefineSearchKeywordInput, keyword);
            ClearAndEnterTextCSSSelector(CSSAttribute.RefineSearchLocationInput, location);
            WaitForElementToBeClickableId(IdAttribute.UpdateLocationButton);
            ClickButton(IdAttribute.UpdateLocationButton);
        }

        private void RefineSearchWithSalary(string location, int? radius, Radius? radiusEnum)
        {
            LocationRefineSearch(location);
            WaitForElementToBeClickableCSSSelector(FormRefineRadiusSelector(radius));
            ClickRefineSearchRadius(radiusEnum);
        }

        private void ClickRefineSearchRadius(Radius? radius)
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
