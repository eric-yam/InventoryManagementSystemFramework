using Microsoft.Playwright;

namespace InventoryManagementSystemFramework.Pages.InventoryPage
{
    public class InventoryItemAdjustmentsPage : InventoryManagementPage
    {
        private InventoryManagementTable table;

        private InventoryItemAdjustmentsPage(IPage page) : base(page)
        {
            this.table = new InventoryManagementTable(this.page, TableRowFactory.CreateInventoryAdjustmentRow);
        }

        public static async Task<InventoryItemAdjustmentsPage> CreateAsync(IPage page)
        {
            InventoryItemAdjustmentsPage iiap = new InventoryItemAdjustmentsPage(page);
            await iiap.table.InitializeTable();            
            return iiap;
        }

        public TableRow GetTableValue(string key)
        {
            return this.table.GetTableValue(key);
        }
    }
}
