using Microsoft.Playwright;

public abstract class TableRow : BaseComponent
{
    //Locators
    private ILocator RowHeaders() => this.page.Locator("table[id='vertically-scrolled-table'] th div div");

    //Components
    protected readonly Dictionary<string, string> Row;
    protected ILocator checkbox;

    public TableRow(IPage page) : base(page)
    {
        this.Row = new Dictionary<string, string>();
    }

    public async Task InitializeRow(ILocator rowLocator)
    {
        var RowHeadersList = await this.RowHeaders().AllAsync();
        this.checkbox = rowLocator.Locator("td:nth-child(1)");

        for (int i = 0; i < RowHeadersList.Count; i++)
        {
            string? key = await RowHeadersList[i].TextContentAsync();
            string? value = await rowLocator.Locator($"td:nth-child({i + 2})").TextContentAsync();

            if (key != null && value != null)
            {
                this.Row.Add(key.Trim(), value.Trim());
            }
        }
    }

    public abstract string CompositeKey();

    public async Task ClickCheckbox()
    {
        if (this.checkbox != null)
        {
            await this.checkbox.ClickAsync();
        }
    }
}
