using System.Threading.Tasks;
using Microsoft.Playwright;

namespace InventoryManagementSystemFramework.Pages.InventoryPage
{
    public class InventoryItemGroupPage : InventoryManagementPage
    {
        private ILocator GroupDropdown() => this.page.Locator("a[class='dropdown-toggle ember-view     no-caret']");
        private ILocator DropdownMenu() => this.page.Locator("div[class='dropdown-menu show  scrollmenu listview-filter'] button[class^='dropdown-item']");

        private InventoryItemGroupPage(IPage page) : base(page) { }

        public static async Task<InventoryItemGroupPage> CreateAsync(IPage page)
        {
            InventoryItemGroupPage iigp = new InventoryItemGroupPage(page);
            await iigp.table.InitializeTable();
            return iigp;
        }

        public override Func<IPage, ILocator, Task<TableRow>> GetRowFactoryMethodReference()
        {
            return TableRowFactory.CreateInventoryItemGroupRow;
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
    }
}