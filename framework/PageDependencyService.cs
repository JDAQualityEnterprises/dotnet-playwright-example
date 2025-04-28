
using Microsoft.Playwright;
using Reqnroll;

namespace ReqnrollTestProject.Services;

public interface IPageDependencyService
{
    Task<IPage> Page { get; }
    ScenarioContext ScenarioContext { get; }
}

public class PageDependencyService : IPageDependencyService, IDisposable
{
    public PageDependencyService(Task<IPage> page, ScenarioContext scenarioContext)
    {
        Page = page;
        Page.Result.SetDefaultTimeout(240000);
        ScenarioContext = scenarioContext;
    }

    public void Dispose()
    {
        Page.Result.Context.Browser?.CloseAsync();
    }

    public Task<IPage> Page { get; }
    public ScenarioContext ScenarioContext { get; }
}