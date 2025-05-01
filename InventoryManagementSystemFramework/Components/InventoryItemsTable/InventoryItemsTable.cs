using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.Playwright;

public class InventoryItemsTable : BaseComponent
{
    private ILocator TableLocator() => this.page.Locator("table[id='vertically-scrolled-table']");
    private Dictionary<string, InventoryItemRow> ItemsTable;

    public InventoryItemsTable(IPage page) : base(page)
    {
        this.ItemsTable = new Dictionary<string, InventoryItemRow>();
    }

    public static async Task<InventoryItemsTable> CreateAsync(IPage page)
    {
        InventoryItemsTable iit = new InventoryItemsTable(page);
        await iit.InitializeTable();
        return iit;
    }

    public async Task InitializeTable()
    {
        this.ItemsTable = new Dictionary<string, InventoryItemRow>();

        await this.TableLocator().WaitForAsync();//this wait is required, otherwise table doesn't populate, loads too fast
        var rowList = await this.TableLocator().Locator("tbody tr").AllAsync();

        foreach (var rowLocator in rowList)
        {
            InventoryItemRow iir = new InventoryItemRow(this.page);
            await iir.InitializeRow(rowLocator);

            //Used Composite Key approach, in the case row objects don't have a unique attribute to identify a row
            string compositeKey = iir.CompositeKey();
            this.ItemsTable.Add(compositeKey, iir);
        }
    }

    public InventoryItemRow GetTableValue(string key)
    {
        return this.ItemsTable[key];
    }
}