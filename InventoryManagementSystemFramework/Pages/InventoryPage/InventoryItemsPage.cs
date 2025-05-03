using Microsoft.Playwright;

namespace InventoryManagementSystemFramework.Pages.InventoryPage
{
    public class InventoryItemsPage : InventoryManagementPage
    {
        private InventoryManagementTable? table;

        private InventoryItemsPage(IPage page) : base(page) { }

        public static async Task<InventoryItemsPage> CreateAsync(IPage page)
        {
            InventoryItemsPage iip = new InventoryItemsPage(page);
            iip.table = await InventoryManagementTable.CreateAsync(page, TableRowFactory.CreateInventoryItemTableRow);//double check 
            return iip;
        }

        public TableRow GetTableValue(string key)
        {
            return this.table.GetTableValue(key);
        }
    }
}
