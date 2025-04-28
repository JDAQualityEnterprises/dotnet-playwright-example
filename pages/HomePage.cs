
using Microsoft.Playwright;

namespace dotnet_playwright_example.pages
{
    internal class HomePage
    {
        private IPage page;
        
        public  ILocator emailLink;

        public HomePage(IPage page) {
            this.page = page;
            emailLink = page.Locator("//a[contains(@href, 'mailto')]");
        }
    }
}
