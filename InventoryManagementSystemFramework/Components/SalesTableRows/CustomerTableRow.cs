using Microsoft.Playwright;

public class CustomerTableRow : TableRow
{
    private ILocator? checkbox;
    private string? name;
    private string? companyName;
    private string? email;
    private string? workPhone;
    private string? receivable;
    private string? unusedCredits;

    public CustomerTableRow(IPage page) : base(page) { }

    public override async Task InitializeRow(ILocator rowLocator)
    {
        this.checkbox = rowLocator.Locator("td:nth-child(1)");
        this.name = await rowLocator.Locator("td:nth-child(2)").TextContentAsync();
        this.companyName = await rowLocator.Locator("td:nth-child(3)").TextContentAsync();
        this.email = await rowLocator.Locator("td:nth-child(4)").TextContentAsync();
        this.workPhone = await rowLocator.Locator("td:nth-child(5)").TextContentAsync();
        this.receivable = await rowLocator.Locator("td:nth-child(6)").TextContentAsync();
        this.unusedCredits = await rowLocator.Locator("td:nth-child(7)").TextContentAsync();
    }
    public override string CompositeKey()
    {
        return $"{this.GetName()}";
    }

    public async Task CheckCheckbox()
    {
        if (this.checkbox != null)
        {
            await this.checkbox.ClickAsync();
        }
    }

    public string GetName() { if (this.name == null) { return ""; } else { return this.name; } }

    public string GetCompanyName() { if (this.companyName == null) { return ""; } else { return companyName; } }

    public string GetEmail() { if (this.email == null) { return ""; } else { return this.email; } }

    public string GetWorkPhone() { if (this.workPhone == null) { return ""; } else { return this.workPhone; } }

    public string GetReceivable() { if (this.receivable == null) { return ""; } else { return this.receivable; } }

    public string GetUnusedCredits() { if (this.unusedCredits == null) { return ""; } else { return this.unusedCredits; } }
}