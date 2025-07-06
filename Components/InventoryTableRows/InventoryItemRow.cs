using Microsoft.Playwright;

public class InventoryItemRow : TableRow
{
    public InventoryItemRow(IPage page) : base(page) { }

    public override string CompositeKey()
    {
        return this.Row["Name"] + "|" + this.Row["SKU"] + "|" + this.Row["Type"];
        // return $"{this.GetName()}|{this.GetSKU()}|{this.GetItemType()}";
    }
}