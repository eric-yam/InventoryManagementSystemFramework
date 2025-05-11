using InventoryManagementSystemFramework.Pages;
using Microsoft.Playwright;

namespace InventoryManagementSystemFramework.Pages.InventoryPage
{
    public abstract class InventoryManagementPage : BasePage
    {
        protected ILocator NewItem() => this.page.Locator("button[class='btn btn-primary']");

        protected ILocator ExitItemOverview() => this.page.Locator("span[class='close-entity close-details ms-4'] path");

        protected InventoryManagementTable table;
        public InventoryManagementPage(IPage page) : base(page)
        {            
            this.table = new InventoryManagementTable(page, this.GetRowFactoryMethodReference());
        }

        public abstract Func<IPage, ILocator, Task<TableRow>> GetRowFactoryMethodReference();

        public async Task ClickNewItem()
        {
            await this.NewItem().ClickAsync();
        }

        public async Task ClickExitItemOverview()
        {
            await this.ExitItemOverview().ClickAsync();
        }

        public TableRow GetTableValue(string key)
        {
            return this.table.GetTableValue(key);
        }
    }
}
