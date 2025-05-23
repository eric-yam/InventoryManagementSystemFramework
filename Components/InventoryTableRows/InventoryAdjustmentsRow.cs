using Microsoft.Playwright;

public class InventoryAdjustmentsRow : TableRow
{
    private ILocator? checkbox;
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

    public override async Task InitializeRow(ILocator rowLocator)
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

    public override string CompositeKey()
    {
        return $"{this.GetDate()}|{this.GetRefNum()}";
    }

    public async Task ClickCheckbox() { if (this.checkbox != null) { await this.checkbox.ClickAsync(); } }

    public string GetDate() { if (this.date == null) { return ""; } else { return this.date; } }

    public string GetDesc() { if (this.desc == null) { return ""; } else { return this.desc; } }

    public string GetStatus() { if (this.status == null) { return ""; } else { return this.status; } }

    public string GetRefNum() { if (this.refNum == null) { return ""; } else { return this.refNum; } }

    public string GetItemType() { if (this.type == null) { return ""; } else { return this.type; } }

    public string GetCreatedBy() { if (this.createdBy == null) { return ""; } else { return this.createdBy; } }

    public string GetCreatedTime() { if (createdTime == null) { return ""; } else { return createdTime; } }

    public string GetLastModifiedBy() { if (this.lastModifiedBy == null) { return ""; } else { return this.lastModifiedBy; } }

    public string GetLastModifiedDate() { if (this.lastModifiedTime == null) { return ""; } else { return this.lastModifiedTime; } }
}