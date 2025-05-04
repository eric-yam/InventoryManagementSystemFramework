using Microsoft.Playwright;

namespace InventoryManagementSystemFramework.Pages.InventoryPage
{
    public class InventoryItemsPage : InventoryManagementPage
    {
        private InventoryManagementTable table;        

        private InventoryItemsPage(IPage page) : base(page)
        {
            this.table = new InventoryManagementTable(page, TableRowFactory.CreateInventoryItemTableRow);
        }

        public static async Task<InventoryItemsPage> CreateAsync(IPage page)
        {
            InventoryItemsPage iip = new InventoryItemsPage(page);
            await iip.table.InitializeTable();            
            return iip;
        }

        public TableRow GetTableValue(string key)
        {
            return this.table.GetTableValue(key);
        }
    }
}
