using Microsoft.Playwright;

public class InventoryItemGroupsRow : TableRow
{
    private ILocator? checkbox;
    private string? name;
    private string? sku;
    private string? stockOnHand;
    private string? reorderPoint;

    public InventoryItemGroupsRow(IPage page) : base(page) { }

    public override async Task InitializeRow(ILocator rowLocator)
    {
        this.checkbox = rowLocator.Locator("td:nth-child(1)");
        this.name = await rowLocator.Locator("td:nth-child(3)").TextContentAsync();
        this.sku = await rowLocator.Locator("td:nth-child(4)").TextContentAsync();
        this.stockOnHand = await rowLocator.Locator("td:nth-child(5)").TextContentAsync();
        this.reorderPoint = await rowLocator.Locator("td:nth-child(6)").TextContentAsync();
    }

    public override string CompositeKey()
    {
        return $"{this.GetName()}|{this.GetSKU()}";
    }
    public async Task CheckCheckbox()
    {
        if (this.checkbox != null)
        {
            await this.checkbox.ClickAsync();
        }
    }
    public string GetName() { if (this.name == null) { return ""; } else { return this.name; } }
    public string GetSKU() { if (this.sku == null) { return ""; } else { return this.sku; } }
    public string GetStockOnHand() { if (this.stockOnHand == null) { return ""; } else { return this.stockOnHand; } }
    public string GetReorderPoint() { if (this.reorderPoint == null) { return ""; } else { return this.reorderPoint; } }
}


