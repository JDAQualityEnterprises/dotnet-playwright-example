using Allure.NUnit;
using dotnet_playwright_example.framework;
using dotnet_playwright_example.pages;

namespace dotnet_playwright_example.tests
{
    [AllureNUnit]
    internal class ContactTest : JdaTest
    {
        [Test]
        public async Task HasTitleAsync()
        {
            var siteInfo = TestData.SiteInfo();

            Assert.That(siteInfo.Title, Is.Not.Null);

            await Expect(Page).ToHaveTitleAsync(siteInfo.Title);
        }

        [Test]
        public async Task HasEmailLinksAsync()
        {
            var siteInfo = TestData.SiteInfo();

            Assert.That(siteInfo.Email, Is.Not.Null);

            ContactPage contactsPage = await new MainMenu(Page).NavigateToContactsAsync();
                
            await Expect(contactsPage.emailLink).ToHaveAttributeAsync("href", $"mailto:{siteInfo.Email}");

            await Expect(contactsPage.footerEmailLink).ToHaveAttributeAsync("href", $"mailto:{siteInfo.Email}");
        }
    }
}
