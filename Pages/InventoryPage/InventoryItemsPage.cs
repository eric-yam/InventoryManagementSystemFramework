using Microsoft.Playwright;

namespace InventoryManagementSystemFramework.Pages.InventoryPage
{
    public class InventoryItemsPage : InventoryManagementPage
    {
        private InventoryItemsPage(IPage page) : base(page) { }

        public static async Task<InventoryItemsPage> CreateAsync(IPage page)
        {
            InventoryItemsPage iip = new InventoryItemsPage(page);
            await iip.table.InitializeTable();
            return iip;
        }

        public override Func<IPage, ILocator, Task<TableRow>> GetRowFactoryMethodReference()
        {
            return TableRowFactory.CreateInventoryItemTableRow;
        }
    }
}
