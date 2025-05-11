using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

public class BaseComponent : PageTest
{
    public IPage page;
    public BaseComponent(IPage page)
    {
        this.page = page;
    }
}