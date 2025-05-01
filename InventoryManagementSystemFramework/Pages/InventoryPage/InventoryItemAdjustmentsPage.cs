using Microsoft.Playwright;

public class InventoryItemAdjustmentsPage : BasePage
{
    private InventoryAdjustmentsTable table;
    public InventoryItemAdjustmentsPage(IPage page) : base(page)
    {
        this.table = new InventoryAdjustmentsTable(page);
    }

    public static async Task<InventoryItemAdjustmentsPage> CreateAsync(IPage page)
    {
        InventoryItemAdjustmentsPage iiap = new InventoryItemAdjustmentsPage(page);
        iiap.table = await InventoryAdjustmentsTable.CreateAsync(page);
        return iiap;
    }
}