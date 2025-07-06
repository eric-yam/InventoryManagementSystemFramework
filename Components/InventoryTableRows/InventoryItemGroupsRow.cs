using Microsoft.Playwright;

public class InventoryItemGroupsRow : TableRow
{
    public InventoryItemGroupsRow(IPage page) : base(page) { }

    public override string CompositeKey()
    {
        return this.Row["Name"] + "|" + this.Row["SKU"];
        // return $"{this.GetName()}|{this.GetSKU()}";
    }
}