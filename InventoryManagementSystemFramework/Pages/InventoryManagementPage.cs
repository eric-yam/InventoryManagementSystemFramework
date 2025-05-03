using InventoryManagementSystemFramework.Pages;
using Microsoft.Playwright;

namespace InventoryManagementSystemFramework.Pages.InventoryPage
{
    public abstract class InventoryManagementPage : BasePage
    {
        protected ILocator NewItem() => this.page.Locator("button[class='btn btn-primary']");

        protected ILocator ExitItemOverview() => this.page.Locator("span[class='close-entity close-details ms-4'] path");

        public InventoryManagementPage(IPage page) : base(page) { }

        public async Task ClickNewItem()
        {
            await this.NewItem().ClickAsync();
        }

        public async Task ClickExitItemOverview()
        {
            await this.ExitItemOverview().ClickAsync();
        }
    }
}
