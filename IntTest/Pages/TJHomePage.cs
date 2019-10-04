namespace IntTest.Pages
{
    internal class TJHomePage : PageBase
    {
        public TJHomePage(PageContext context) : base(context)
        {

        }

        public void MoreOptions(string salary, string salaryAmount, string jobType, string recruiterType)
        {
            this.ClickButton(IdAttribute.moreOptionsToggle);
            this.WaitForElementToBeClickableId(IdAttribute.allSalaries);

            switch (salary)
            {
                case "Annual":
                    this.ClickButton(IdAttribute.annualSalary);
                    this.SelectValueFromDropdown(IdAttribute.salaryRate, salaryAmount);
                    break;
                case "Daily":
                    this.ClickButton(IdAttribute.dailySalary);
                    this.SelectValueFromDropdown(IdAttribute.salaryRate, salaryAmount);
                    break;
                case "Hourly":
                    this.ClickButton(IdAttribute.hourlySalary);
                    this.SelectValueFromDropdown(IdAttribute.salaryRate, salaryAmount);
                    break;
                default:
                    this.ClickButton(IdAttribute.allSalaries);
                    break;
            }

            this.SelectTextFromDropdown(IdAttribute.jobTypeDdl, jobType);

            switch (recruiterType)
            {
                case "employer":
                    this.ClickButton(IdAttribute.recruiterTypeEmployer);
                    break;
                case "agency":
                    this.ClickButton(IdAttribute.recruiterTypeAgency);
                    break;
                default:
                    this.ClickButton(IdAttribute.recruiterTypeAll);
                    break;
            }

        }

        internal static class IdAttribute
        {
            public static string positionTxt => "keywords";

            public static string locationTxt => "location";

            public static string distanceDdl => "Radius";

            public static string searchBtn => "search-button";

            public static string moreOptionsToggle => "more-options-toggle";

            public static string allSalaries => "salaryButtonAll";

            public static string annualSalary => "salaryButtonAnnual";

            public static string dailySalary => "salaryButtonDaily";

            public static string salaryRate => "salaryRate";

            public static string hourlySalary => "salaryButtonHourly";

            public static string jobTypeDdl => "JobType";

            public static string recruiterTypeAll => "recruiterTypeButtonAny";

            public static string recruiterTypeEmployer => "recruiterTypeButtonEmployer";

            public static string recruiterTypeAgency => "recruiterTypeButtonAgency";
        }
    }
}
