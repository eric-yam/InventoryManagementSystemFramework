using Microsoft.Playwright;

public class InventoryItemRow : BaseComponent
{
    private ILocator checkbox;
    private string? name;
    private string? sku;
    private string? type;
    private string? desc;
    private string? rate;

    public InventoryItemRow(IPage page) : base(page) { }

    public async Task InitializeRow(ILocator rowLocator)
    {
        this.checkbox = rowLocator.Locator("input[type='checkbox']");
        this.name = await rowLocator.Locator("a").TextContentAsync();
        this.sku = await rowLocator.Locator("td:nth-child(3)").TextContentAsync();
        this.type = await rowLocator.Locator("td:nth-child(4)").TextContentAsync();
        this.desc = await rowLocator.Locator("td span[class='text-ellipsis']").TextContentAsync();
        this.rate = await rowLocator.Locator("td[class='  text-end']").TextContentAsync();
    }

    public string CompositeKey()
    {
        return $"{this.GetName()}|{this.GetSKU()}|{this.GetItemType()}";
    }

    public async Task ClickCheckbox() { await this.checkbox.ClickAsync(); }

    public string GetName() { return this.name; }

    public string GetSKU() { return this.sku; }

    public string GetItemType() { return this.type; }

    public string GetDesc() { return this.desc; }

    public string GetRate() { return this.rate; }

}