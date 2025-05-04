using System.Threading.Tasks;
using Microsoft.Playwright;

namespace InventoryManagementSystemFramework.Pages.InventoryPage
{
    public class InventoryItemGroupPage : InventoryManagementPage
    {
        private ILocator GroupDropdown() => this.page.Locator("a[class='dropdown-toggle ember-view     no-caret']");
        private ILocator DropdownMenu() => this.page.Locator("div[class='dropdown-menu show  scrollmenu listview-filter'] button[class^='dropdown-item']");
        private InventoryManagementTable table;

        private InventoryItemGroupPage(IPage page) : base(page)
        {
            this.table = new InventoryManagementTable(page, TableRowFactory.CreateInventoryItemGroupRow);
        }

        public static async Task<InventoryItemGroupPage> CreateAsync(IPage page)
        {
            InventoryItemGroupPage iigp = new InventoryItemGroupPage(page);            
            await iigp.table.InitializeTable();
            return iigp;
        }

        public async Task SelectDropdownOption(string groupOption)
        {
            await this.GroupDropdown().ClickAsync();
            var menuList = await this.DropdownMenu().AllAsync();

            foreach (var menuOption in menuList)
            {
                string? s = await menuOption.TextContentAsync();
                if (s != null && s.Equals(groupOption))
                {
                    await menuOption.ClickAsync();
                    break;
                }
            }
        }

        public TableRow GetTableValue(string key)
        {
            return this.table.GetTableValue(key);
        }
    }
}