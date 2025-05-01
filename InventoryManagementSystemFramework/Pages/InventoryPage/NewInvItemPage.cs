using Microsoft.Playwright;

public class NewInvItemPage : BasePage
{
    //Only Mandatory fields included so far.

    // input[value='goods']
    // input[value='service']
    public ILocator InvItemType(string type) => this.page.Locator($"input[value='{type}']");

    public ILocator NameInput() => this.page.Locator("div[class='form-group'] input");

    public ILocator SKUInput() => this.page.Locator("//label[@class='col-lg-3 col-form-label' and contains(string(), 'SKU')]//following-sibling::div//descendant::input");

    public ILocator UnitDropdown() => this.page.Locator("//label[@class='col-lg-3 col-form-label' and contains(string(), 'Unit')]//following-sibling::div");

    public ILocator UnitDropdownOption(string unitOption) => this.page.Locator($"div[title='{unitOption}']");

    public ILocator SellingPriceInput() => this.page.Locator("(//div[@class='input-group-prepend']//following-sibling::input)[1]");

    public ILocator CostPriceInput() => this.page.Locator("(//div[@class='input-group-prepend']//following-sibling::input)[2]");

    public ILocator SaveButton() => this.page.Locator("button[type='submit']");

    public ILocator CancelButton() => this.page.Locator("button[class='btn btn-secondary']");
    public NewInvItemPage(IPage page) : base(page) { }

    public async Task CheckInvItemType(string type)
    {
        await this.InvItemType(type).ClickAsync();
    }
    public async Task FillNameInput(string name)
    {
        await this.NameInput().FillAsync(name);
    }

    public async Task FillSKUInput(string sku)
    {
        await this.SKUInput().FillAsync(sku);
    }

    public async Task SelectUnit(string unitOption)
    {
        await this.UnitDropdown().ClickAsync();
        await this.UnitDropdownOption(unitOption).ClickAsync();
    }

    public async Task FillSellPrice(double value)
    {
        await this.SellingPriceInput().FillAsync(value.ToString());
    }

    public async Task FillCostPrice(double value)
    {
        await this.CostPriceInput().FillAsync(value.ToString());
    }

    public async Task ClickSaveButton()
    {
        await this.SaveButton().ClickAsync();
    }

    public async Task ClickCancelButton()
    {
        await this.CancelButton().ClickAsync();
    }
}