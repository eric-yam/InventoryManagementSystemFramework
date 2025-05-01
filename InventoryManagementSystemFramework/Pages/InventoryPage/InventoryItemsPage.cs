using Microsoft.Playwright;

public class InventoryItemsPage : BasePage
{
    private ILocator NewItem() => this.page.Locator("button[class='btn btn-primary']");

    private ILocator ExitItemOverview() => this.page.Locator("span[class='close-entity close-details ms-4'] path");

    private InventoryItemsTable table;
    private InventoryItemsPage(IPage page) : base(page)
    {
        this.table = new InventoryItemsTable(page);
    }

    public static async Task<InventoryItemsPage> CreateAsync(IPage page)
    {
        InventoryItemsPage iip = new InventoryItemsPage(page);
        iip.table = await InventoryItemsTable.CreateAsync(page);//double check 
        return iip;
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