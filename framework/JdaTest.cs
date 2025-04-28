using Microsoft.Playwright.NUnit;

namespace dotnet_playwright_example.framework
{
    internal class JdaTest : PageTest
    {
        protected TestData TestData => new();


        [SetUp]
        public async Task SetUp()
        {
            var baseUrl = TestContext.Parameters.Get("BaseUrl");

            await Page.GotoAsync(baseUrl ?? "https://www.jdaqualitylimited.com");
        }
    }
}
