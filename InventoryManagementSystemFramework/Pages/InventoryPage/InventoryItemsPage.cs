using Microsoft.Playwright;
namespace InventoryManagementSystemFramework.Pages.InventoryPage
{
    public class InventoryItemsPage : InventoryManagementPage
    {
        private InventoryItemsTable table;
        private InventoryItemsPage(IPage page) : base(page)
        {
            this.table = new InventoryItemsTable(page);
        }

        public static async Task<InventoryItemsPage> CreateAsync(IPage page)
        {
            InventoryItemsPage iip = new InventoryItemsPage(page);
            iip.table = await InventoryItemsTable.CreateAsync(page);//double check 
            return iip;
        }

        public InventoryItemRow GetTableValue(string key)
        {
            return this.table.GetTableValue(key);
        }
    }
}
