using InventoryManagementSystemFramework.TestDataWorkflows;
using Microsoft.Playwright;

public class InventoryAdjustmentsRow : TableRow
{
    public InventoryAdjustmentsRow(IPage page) : base(page) { }

    public override string CompositeKey()
    {
        return this.Row["Reference Number"];
    }
}