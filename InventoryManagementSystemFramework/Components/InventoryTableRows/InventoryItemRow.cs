using Microsoft.Playwright;

public class InventoryItemRow : TableRow
{
    private ILocator? checkbox;
    private string? name;
    private string? sku;
    private string? type;
    private string? desc;
    private string? rate;

    public InventoryItemRow(IPage page) : base(page) { }

    public override async Task InitializeRow(ILocator rowLocator)
    {
        this.checkbox = rowLocator.Locator("input[type='checkbox']");
        this.name = await rowLocator.Locator("a").TextContentAsync();
        this.sku = await rowLocator.Locator("td:nth-child(3)").TextContentAsync();
        this.type = await rowLocator.Locator("td:nth-child(4)").TextContentAsync();
        this.desc = await rowLocator.Locator("td span[class='text-ellipsis']").TextContentAsync();
        this.rate = await rowLocator.Locator("td[class='  text-end']").TextContentAsync();
    }

    public override string CompositeKey()
    {
        return $"{this.GetName()}|{this.GetSKU()}|{this.GetItemType()}";
    }

    public async Task ClickCheckbox()
    {
        if (this.checkbox != null)
        {
            await this.checkbox.ClickAsync();
        }

    }

    public string GetName()
    {
        if (this.name == null)
        {
            return "";
        }
        else
        {
            return this.name;
        }
    }

    public string GetSKU()
    {
        if (this.sku == null)
        {
            return "";
        }
        else
        {
            return this.sku;
        }

    }

    public string GetItemType()
    {
        if (this.type == null)
        {
            return "";
        }
        else
        {
            return this.type;
        }

    }

    public string GetDesc()
    {
        if (this.desc == null)
        {
            return "";
        }
        else
        {
            return this.desc;
        }

    }

    public string GetRate()
    {
        if (this.rate == null)
        {
            return "";
        }
        else
        {
            return this.rate;
        }
    }
}