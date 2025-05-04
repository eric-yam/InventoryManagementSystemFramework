using Microsoft.Playwright;

public class TableRowFactory
{
    public static async Task<TableRow> CreateInventoryItemTableRow(IPage page, ILocator rowLocator)
    {
        InventoryItemRow iir = new InventoryItemRow(page);
        await iir.InitializeRow(rowLocator);
        return iir;
    }

    public static async Task<TableRow> CreateInventoryItemGroupRow(IPage page, ILocator rowLocator)
    {
        InventoryItemGroupsRow iigr = new InventoryItemGroupsRow(page);
        await iigr.InitializeRow(rowLocator);
        return iigr;
    }

    public static async Task<TableRow> CreateInventoryAdjustmentRow(IPage page, ILocator rowLocator)
    {
        InventoryAdjustmentsRow iar = new InventoryAdjustmentsRow(page);
        await iar.InitializeRow(rowLocator);
        return iar;
    }
}