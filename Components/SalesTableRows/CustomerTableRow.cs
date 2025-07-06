using Microsoft.Playwright;

public class CustomerTableRow : TableRow
{
    public CustomerTableRow(IPage page) : base(page) { }

    public override string CompositeKey()
    {
        return this.Row["Name"];
    }
}