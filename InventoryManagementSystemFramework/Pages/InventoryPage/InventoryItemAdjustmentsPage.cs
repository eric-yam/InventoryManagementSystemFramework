using Microsoft.Playwright;

namespace InventoryManagementSystemFramework.Pages.InventoryPage
{
    public class InventoryItemAdjustmentsPage : InventoryManagementPage
    {
        private InventoryManagementTable table;
        public InventoryItemAdjustmentsPage(IPage page) : base(page) { }

        public static async Task<InventoryItemAdjustmentsPage> CreateAsync(IPage page)
        {
            InventoryItemAdjustmentsPage iiap = new InventoryItemAdjustmentsPage(page);
            iiap.table = await InventoryManagementTable.CreateAsync(page, TableRowFactory.CreateInventoryAdjustmentRow);
            return iiap;
        }

        public TableRow GetTableValue(string key)
        {
            return this.table.GetTableValue(key);
        }
    }
}
