using Microsoft.Playwright;

public abstract class BasePage
{
    public IPage page;

    public BasePage(IPage page)
    {
        this.page = page;
    }
}