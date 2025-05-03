using Microsoft.Playwright;

public class TableRowFactory
{
    public static async Task<TableRow> CreateInventoryItemTableRow(IPage page, ILocator rowLocator)
    {
        InventoryItemRow iir = new InventoryItemRow(page);
        await iir.InitializeRow(rowLocator);
        return iir;
    }
}