using Microsoft.Playwright;

public class SalesOrderTableRow : TableRow
{
    private ILocator? checkbox;
    private string? date;
    private string? salesOrderNum;
    private string? referenceNum;
    private string? customerName;
    private string? status;
    private string? amount;

    public SalesOrderTableRow(IPage page) : base(page) { }
    public override string CompositeKey()
    {
        return $"{this.GetSalesOrderNumber()}|{this.GetCustomerName()}";
    }

    public override async Task InitializeRow(ILocator rowLocator)
    {
        this.checkbox = rowLocator.Locator("input");
        this.date = await rowLocator.Locator("td:nth-child(2)").TextContentAsync();
        this.salesOrderNum = await rowLocator.Locator("td:nth-child(3)").TextContentAsync();
        this.referenceNum = await rowLocator.Locator("td:nth-child(4)").TextContentAsync();
        this.customerName = await rowLocator.Locator("td:nth-child(5)").TextContentAsync();
        this.status = await rowLocator.Locator("td:nth-child(6)").TextContentAsync();
        this.amount = await rowLocator.Locator("td:nth-child(7)").TextContentAsync();
    }

    public async Task CheckCheckbox()
    {
        if (this.checkbox != null)
        {
            await this.checkbox.ClickAsync();
        }
    }

    public string GetDate() { if (this.date == null) { return ""; } else { return this.date; } }

    public string GetSalesOrderNumber() { if (this.salesOrderNum == null) { return ""; } else { return this.salesOrderNum; } }

    public string GetReferenceNumber() { if (this.referenceNum == null) { return ""; } else { return this.referenceNum; } }

    public string GetCustomerName() { if (this.customerName == null) { return ""; } else { return this.customerName; } }

    public string GetStatus() { if (this.status == null) { return ""; } else { return this.status; } }

    public string GetAmount() { if (this.amount == null) { return ""; } else { return this.amount; } }

}