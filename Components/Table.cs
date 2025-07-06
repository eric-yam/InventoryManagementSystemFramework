using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.Playwright;

public class Table : BaseComponent
{
    protected ILocator TableLocator() => this.page.Locator("table[id='vertically-scrolled-table']");
    protected Dictionary<string, TableRow> table;
    protected Func<IPage, ILocator, Task<TableRow>> rowFactoryMethodReference;

    public Table(IPage page, Func<IPage, ILocator, Task<TableRow>> methodReference) : base(page)
    {
        this.rowFactoryMethodReference = methodReference;
        this.table = new Dictionary<string, TableRow>();
    }

    //Mutators methods
    public async Task InitializeTable()
    {
        this.table = new Dictionary<string, TableRow>();
        try
        {
            //Wait is required to verify table is empty, otherwise automation loads faster than webpage and will always return empty
            //Wait 3 seconds
            await this.TableLocator().WaitForAsync(new LocatorWaitForOptions { Timeout = 3000 });//this wait is required, otherwise table doesn't populate, loads too fast
        }
        catch (TimeoutException)
        {
            //When table locator finds nothing, table is empty, exit method
            return;
        }

        // await this.TableLocator().WaitForAsync();//this wait is required, otherwise table doesn't populate, loads too fast
        var rowList = await this.TableLocator().Locator("tbody tr").AllAsync();

        foreach (var rowLocator in rowList)
        {
            string? s = await rowLocator.TextContentAsync();
            if (s != null && !s.Equals("No Records Found"))
            {
                TableRow tableRow = await this.rowFactoryMethodReference(this.page, rowLocator);

                //Used Composite Key approach, in the case row objects don't have a unique attribute to identify a row
                string compositeKey = tableRow.CompositeKey();
                this.table.Add(compositeKey, tableRow);
            }
        }
    }

    //Getter methods
    public Dictionary<string, TableRow> GetTable() { return this.table; }
    public int GetTableSize() { return this.table.Count; }
    public TableRow GetTableRow(string key) { return this.table[key]; }
}