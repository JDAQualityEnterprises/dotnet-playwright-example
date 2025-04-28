using dotnet_playwright_example.framework;
using dotnet_playwright_example.model;
using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using Reqnroll;
using ReqnrollTestProject.Services;
using dotnet_playwright_example.pages;

namespace c_sharp_playwright_example.Steps.Contact

{
    [Binding]
    public class ContactSteps(IPageDependencyService pageDependencyService)
    {
        private readonly ScenarioContext _scenarioContext = pageDependencyService.ScenarioContext;
        private IPage page = pageDependencyService.Page.Result;
        private SiteInfo siteInfo = new TestData().SiteInfo();

        [Then("the correct title is displayed for the contact page")]
        public async Task ThenTheCorrectTitleIsDisplayedForTheContactPageAsync()
        {
            await Expect(page).ToHaveTitleAsync(siteInfo.Title + " - Contact");
        }

        [When("User navigates to the contact page")]
        public async Task WhenUserNavigatesToTheContactPageAsync()
        {
            var baseUrl = TestContext.Parameters.Get("BaseUrl");

            await page.GotoAsync(baseUrl ?? "https://www.jdaqualitylimited.com");

            ContactPage contactPage = await new MainMenu(page).NavigateToContactsAsync();

            _scenarioContext.Add("contactPage", contactPage);

        }

        [When("the contact email is displayed correctly")]
        public async Task WhenTheContactEmailIsDisplayedCorrectlyAsync()
        {
            Assert.That(siteInfo.Email, Is.Not.Null);

            var contactPage = _scenarioContext.Get<ContactPage>("contactPage");

            await Expect(contactPage.emailLink).ToHaveAttributeAsync("href", $"mailto:{siteInfo.Email}");

            await Expect(contactPage.footerEmailLink).ToHaveAttributeAsync("href", $"mailto:{siteInfo.Email}");

        }
    }
}
