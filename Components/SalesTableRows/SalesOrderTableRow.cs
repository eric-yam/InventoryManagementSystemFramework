using Microsoft.Playwright;

public class SalesOrderTableRow : TableRow
{
    public SalesOrderTableRow(IPage page) : base(page) { }
    public override string CompositeKey()
    {
        return this.Row["Sales Order#"] + "|" + this.Row["CustomerName"];
    }
}