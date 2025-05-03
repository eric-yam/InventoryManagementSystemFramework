using InventoryManagementSystemFramework.Pages;
using InventoryManagementSystemFramework.Pages.InventoryPage;
using Microsoft.Playwright;

public abstract class InventoryManagementPage : BasePage
{
    protected ILocator NewItem() => this.page.Locator("button[class='btn btn-primary']");

    protected ILocator ExitItemOverview() => this.page.Locator("span[class='close-entity close-details ms-4'] path");

    private InventoryItemsTable table;
    public InventoryManagementPage(IPage page) : base(page)
    {
        this.table = new InventoryItemsTable(page);
    }

    public async Task ClickNewItem()
    {
        await this.NewItem().ClickAsync();
    }

    public async Task ClickExitItemOverview()
    {
        await this.ExitItemOverview().ClickAsync();
    }

    public InventoryItemRow GetTableValue(string key)
    {
        return this.table.GetTableValue(key);
    }
}