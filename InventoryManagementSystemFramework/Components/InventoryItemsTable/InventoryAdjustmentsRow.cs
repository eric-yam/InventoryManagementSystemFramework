using Microsoft.Playwright;

public class InventoryAdjustmentsRow : BaseComponent
{
    private ILocator checkbox;
    private string? date;
    private string? desc;
    private string? status;
    private string? refNum;
    private string? type;
    private string? createdBy;
    private string? createdTime;
    private string? lastModifiedBy;
    private string? lastModifiedTime;

    public InventoryAdjustmentsRow(IPage page) : base(page) { }

    public async Task InitializeRow(ILocator rowLocator)
    {
        this.checkbox = rowLocator.Locator("td:nth-child(1)");
        this.date = await rowLocator.Locator("td:nth-child(2)").TextContentAsync();
        this.desc = await rowLocator.Locator("td:nth-child(3)").TextContentAsync();
        this.status = await rowLocator.Locator("td:nth-child(4)").TextContentAsync();
        this.refNum = await rowLocator.Locator("td:nth-child(5)").TextContentAsync();
        this.type = await rowLocator.Locator("td:nth-child(6)").TextContentAsync();
        this.createdBy = await rowLocator.Locator("td:nth-child(7)").TextContentAsync();
        this.createdTime = await rowLocator.Locator("td:nth-child(8)").TextContentAsync();
        this.lastModifiedBy = await rowLocator.Locator("td:nth-child(9)").TextContentAsync();
        this.lastModifiedTime = await rowLocator.Locator("td:nth-child(10)").TextContentAsync();

    }

    public string CompositeKey()
    {
        return $"{this.GetDate()}|{this.GetRefNum()}";
    }

    public async Task ClickCheckbox() { await this.checkbox.ClickAsync(); }

    public string GetDate() { return this.date; }

    public string GetDesc() { return this.desc; }

    public string GetStatus() { return this.status; }

    public string GetRefNum() { return this.refNum; }

    public string GetItemType() { return this.type; }

    public string GetCreatedBy() { return this.createdBy; }

    public string GetCreatedTime() { return this.createdTime; }

    public string GetLastModifiedBy() { return this.lastModifiedBy; }

    public string GetLastModifiedDate() { return this.lastModifiedTime; }



}