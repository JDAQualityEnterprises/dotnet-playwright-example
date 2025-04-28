using Microsoft.Playwright;

namespace dotnet_playwright_example.pages
{
    internal class ContactPage
    {
        public ILocator emailLink;
        public ILocator footerEmailLink;
        public ILocator heading;

        public ContactPage(IPage page)
        {
            emailLink = page.Locator("//a[contains(@href, 'mailto')]").First;
            footerEmailLink = page.Locator("footer").Locator("//a[contains(@href, 'mailto')]");

            heading = page.GetByRole(AriaRole.Heading, new() { Name = "Contact" }).First;
        }

        public async Task<bool> IsDisplayedAsync() {
            await Assertions.Expect(heading).ToBeVisibleAsync();

            return true;
        }
    }
}
