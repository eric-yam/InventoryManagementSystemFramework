using Microsoft.Playwright;

public abstract class TableRow : BaseComponent
{
    public TableRow(IPage page) : base(page) { }

    public abstract Task InitializeRow(ILocator rowLocator);
    public abstract string CompositeKey();
}
