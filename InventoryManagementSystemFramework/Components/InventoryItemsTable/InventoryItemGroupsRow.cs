using Microsoft.Playwright;

public class InventoryItemGroupsRow : BaseComponent
{
    private ILocator? checkbox;
    private string? name;
    private string? sku;
    private string? stockOnHand;
    private string? reorderPoint;



    public InventoryItemGroupsRow(IPage page) : base(page) { }

    public async Task InitializeRow(ILocator rowLocator)
    {
        this.checkbox = rowLocator.Locator("td:nth-child(1)");
        this.name = await rowLocator.Locator("td:nth-child(3)").TextContentAsync();
        this.sku = await rowLocator.Locator("td:nth-child(4)").TextContentAsync();
        this.stockOnHand = await rowLocator.Locator("td:nth-child(5)").TextContentAsync();
        this.reorderPoint = await rowLocator.Locator("td:nth-child(6)").TextContentAsync();
    }

    public string CompositeKey()
    {
        return $"{this.GetName()}|{this.GetSKU()}";
    }
    public async Task CheckCheckbox()
    {
        await this.checkbox.ClickAsync();
    }
    public string GetName() { return this.name; }
    public string GetSKU() { return this.sku; }
    public string GetStockOnHand() { return this.stockOnHand; }
    public string GetReorderPoint() { return this.reorderPoint; }
}


