
using Microsoft.Playwright;

namespace dotnet_playwright_example.pages
{
    internal class MainMenu
    {
        private IPage page;

        public ILocator mainMenu;
        public ILocator homeLink;
        public ILocator contactsLink;
        public ILocator clientsLink;
        public ILocator aboutLink;

        public MainMenu(IPage page)
        {
            this.page = page;
            mainMenu = page.GetByRole(AriaRole.Navigation);
            homeLink = mainMenu.GetByRole(AriaRole.Link, new() { Name = "Home" });
            contactsLink = mainMenu.GetByRole(AriaRole.Link, new() { Name = "Contact" });
            clientsLink = mainMenu.GetByRole(AriaRole.Link, new() { Name = "Clients" });
            aboutLink = mainMenu.GetByRole(AriaRole.Link, new() { Name = "About" });
        }

        internal async Task<ContactPage> NavigateToContactsAsync()
        {
            await contactsLink.ClickAsync();

            var contactsPage = new ContactPage(page);
            
            await contactsPage.IsDisplayedAsync();

            return contactsPage;
        }
    }
}
