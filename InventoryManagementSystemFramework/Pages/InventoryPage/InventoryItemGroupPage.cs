using System.Threading.Tasks;
using Microsoft.Playwright;

namespace InventoryManagementSystemFramework.Pages.InventoryPage
{
    public class InventoryItemGroupPage : BasePage
    {
        private ILocator GroupDropdown() => this.page.Locator("a[class='dropdown-toggle ember-view     no-caret']");
        private ILocator DropdownMenu() => this.page.Locator("div[class='dropdown-menu show  scrollmenu listview-filter'] button[class^='dropdown-item']");
        private InventoryItemGroupsTables table;
        public InventoryItemGroupPage(IPage page) : base(page)
        {
            this.table = new InventoryItemGroupsTables(page);
        }

        public static async Task<InventoryItemGroupPage> CreateAsync(IPage page)
        {
            InventoryItemGroupPage iigp = new InventoryItemGroupPage(page);
            iigp.table = await InventoryItemGroupsTables.CreateAsync(page);//double check 
            return iigp;
        }

        public async Task SelectDropdownOption(string groupOption)
        {
            await this.GroupDropdown().ClickAsync();
            var menuList = await this.DropdownMenu().AllAsync();

            foreach (var menuOption in menuList)
            {
                string? s = await menuOption.TextContentAsync();
                if (s.Equals(groupOption))
                {
                    await menuOption.ClickAsync();
                    break;
                }
            }
        }
    }
}