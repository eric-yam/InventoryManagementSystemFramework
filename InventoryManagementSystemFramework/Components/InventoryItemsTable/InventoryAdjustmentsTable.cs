using Microsoft.Playwright;

public class InventoryAdjustmentsTable : BaseComponent
{
    private ILocator TableLocator() => this.page.Locator("table[id='vertically-scrolled-table']");
    private Dictionary<string, InventoryAdjustmentsRow> ItemsTable;
    public InventoryAdjustmentsTable(IPage page) : base(page)
    {
        this.ItemsTable = new Dictionary<string, InventoryAdjustmentsRow>();
    }

    public static async Task<InventoryAdjustmentsTable> CreateAsync(IPage page)
    {
        InventoryAdjustmentsTable iiat = new InventoryAdjustmentsTable(page);
        await iiat.InitializeTable();
        return iiat;
    }

    public async Task InitializeTable()
    {
        this.ItemsTable = new Dictionary<string, InventoryAdjustmentsRow>();

        await this.TableLocator().WaitForAsync();//this wait is required, otherwise table doesn't populate, loads too fast
        var rowList = await this.TableLocator().Locator("tbody tr").AllAsync();

        foreach (var rowLocator in rowList)
        {
            InventoryAdjustmentsRow iir = new InventoryAdjustmentsRow(this.page);
            await iir.InitializeRow(rowLocator);

            //Used Composite Key approach, in the case row objects don't have a unique attribute to identify a row
            string compositeKey = iir.CompositeKey();
            this.ItemsTable.Add(compositeKey, iir);
        }
    }

    public InventoryAdjustmentsRow GetTableValue(string key)
    {
        return this.ItemsTable[key];
    }
}