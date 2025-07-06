using InventoryManagementSystemFramework.TestDataWorkflows;
using Microsoft.Playwright;

public class InventoryAdjustmentsRow : TableRow
{
    private ILocator? checkbox;
    private ILocator RowHeaders() => this.page.Locator("table[id='vertically-scrolled-table'] th div div");
    private readonly Dictionary<string, string> Row;
    public InventoryAdjustmentsRow(IPage page) : base(page)
    {
        this.Row = new Dictionary<string, string>();
    }

    public override async Task InitializeRow(ILocator rowLocator)
    {

        var RowHeadersList = await this.RowHeaders().AllAsync();

        for (int i = 0; i < RowHeadersList.Count; i++)
        {
            string? key = await RowHeadersList[i].TextContentAsync();
            string? value = await rowLocator.Locator($"td:nth-child({i + 2})").TextContentAsync();

            if (key != null && value != null)
            {
                this.Row.Add(key, value);
            }
        }
    }

    public override string CompositeKey()
    {
        return this.Row["Reference Number "];
    }

    public async Task ClickCheckbox() { if (this.checkbox != null) { await this.checkbox.ClickAsync(); } }

}