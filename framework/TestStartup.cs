using Autofac;
using Microsoft.Playwright;
using Reqnroll.Autofac;
using ReqnrollTestProject.Services;

namespace ReqnrollTestProject;

public static class TestStartup
{
    [ScenarioDependencies]
    public static void CreateServices(ContainerBuilder builder)
    {
        builder.RegisterPlaywright();
        builder.RegisterPageDependencyService();
        builder.RegisterSteps();
    }

    private static void RegisterSteps(this ContainerBuilder builder)
    {
        builder.RegisterType<c_sharp_playwright_example.Steps.Home.HomeSteps>().InstancePerDependency();
        builder.RegisterType<c_sharp_playwright_example.Steps.Contact.ContactSteps>().InstancePerDependency();
    }

    private static void RegisterPlaywright(this ContainerBuilder builder)
    {
        builder.Register(async _ =>
        {
            var playwright = await Playwright.CreateAsync().ConfigureAwait(false);
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = true,
                SlowMo = 200
            }).ConfigureAwait(false);
            return await browser.NewPageAsync().ConfigureAwait(false);
        }).As<Task<IPage>>().InstancePerDependency();
    }

    private static void RegisterPageDependencyService(this ContainerBuilder builder)
    {
        builder.RegisterType<PageDependencyService>().As<IPageDependencyService>().InstancePerLifetimeScope();
    }
}
