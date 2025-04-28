using dotnet_playwright_example.framework;
using dotnet_playwright_example.model;
using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using Reqnroll;
using ReqnrollTestProject.Services;
using dotnet_playwright_example.pages;

namespace c_sharp_playwright_example.Steps.Home

{
    [Binding]
    public class HomeSteps(IPageDependencyService pageDependencyService)
    {
        private readonly ScenarioContext _scenarioContext = pageDependencyService.ScenarioContext;
        private IPage page = pageDependencyService.Page.Result;
        private SiteInfo siteInfo = new TestData().SiteInfo();

        [Given(@"User has site details")]
        public void GivenUserHasSiteDetails()
        {
            Assert.That(siteInfo.Title, Is.Not.Null);

            _scenarioContext.Add("data", siteInfo);
        }

        [When("User navigates to the home page")]
        public async Task WhenUserNavigatesToTheHomePageAsync()
        {
            var baseUrl = TestContext.Parameters.Get("BaseUrl");

            await page.GotoAsync(baseUrl ?? "https://www.jdaqualitylimited.com");

            _scenarioContext.Add("homePage", new HomePage(page));
        }

        [Then("the correct title is displayed for the home page")]
        public async Task ThenTheCorrectTitleIsDisplayedForTheHomePageAsync()
        {
            await Expect(page).ToHaveTitleAsync(siteInfo.Title);
        }

        [Then("the navigation links are correct")]
        public void ThenTheNavigationLinksAreCorrect()
        {
            var menu = new MainMenu(page);

            Assert.Multiple(async () =>
            {
                Assert.That(await menu.homeLink.GetAttributeAsync("href"), Is.EqualTo("/home"));
                Assert.That(await menu.contactsLink.GetAttributeAsync("href"), Is.EqualTo("/contact"));
                Assert.That(await menu.clientsLink.GetAttributeAsync("href"), Is.EqualTo("/clients"));
                Assert.That(await menu.aboutLink.GetAttributeAsync("href"), Is.EqualTo("/about-us"));
            });
        }

        [Then("the email is displayed correctly")]
        public async Task ThenTheEmailIsDisplayedCorrectlyAsync()
        {
            var homePage = _scenarioContext.Get<HomePage>("homePage");

            await Expect(homePage.emailLink).ToHaveAttributeAsync("href", $"mailto:{siteInfo.Email}");
        }
    }
}
