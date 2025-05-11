using Microsoft.Playwright;

namespace InventoryManagementSystemFramework.Pages.InventoryPage
{
    public class InventoryItemAdjustmentsPage : InventoryManagementPage
    {

        private InventoryItemAdjustmentsPage(IPage page) : base(page) { }

        public static async Task<InventoryItemAdjustmentsPage> CreateAsync(IPage page)
        {
            InventoryItemAdjustmentsPage iiap = new InventoryItemAdjustmentsPage(page);
            await iiap.table.InitializeTable();
            return iiap;
        }

        public override Func<IPage, ILocator, Task<TableRow>> GetRowFactoryMethodReference()
        {
            return TableRowFactory.CreateInventoryAdjustmentRow;
        }
    }
}
