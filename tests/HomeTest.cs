using Allure.NUnit;
using dotnet_playwright_example.framework;
using dotnet_playwright_example.pages;

namespace dotnet_playwright_example.tests;

[Parallelizable(ParallelScope.Self)]
[TestFixture, AllureNUnit]
internal class HomeTest : JdaTest
{
    [Test]
    public async Task HasTitleAsync()
    {
        var siteInfo = TestData.SiteInfo();

        Assert.That(siteInfo.Title, Is.Not.Null);

        await Expect(Page).ToHaveTitleAsync(siteInfo.Title);
    }

    [Test]
    public void HasLinksAsync()
    {
        var menu = new MainMenu(Page);

        Assert.Multiple(async () =>
        {
            Assert.That(await menu.homeLink.GetAttributeAsync("href"), Is.EqualTo("/home"));
            Assert.That(await menu.contactsLink.GetAttributeAsync("href"), Is.EqualTo("/contact"));
            Assert.That(await menu.clientsLink.GetAttributeAsync("href"), Is.EqualTo("/clients"));
            Assert.That(await menu.aboutLink.GetAttributeAsync("href"), Is.EqualTo("/about-us"));
        });
    }
}
