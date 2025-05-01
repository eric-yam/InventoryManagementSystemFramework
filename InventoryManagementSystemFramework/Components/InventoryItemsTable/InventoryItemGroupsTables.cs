using System.ComponentModel;
using Microsoft.Playwright;

public class InventoryItemGroupsTables : BaseComponent
{
    private ILocator TableLocator() => this.page.Locator("table[id='vertically-scrolled-table']");
    private Dictionary<string, InventoryItemGroupsRow> ItemsTable;
    public InventoryItemGroupsTables(IPage page) : base(page)
    {
        this.ItemsTable = new Dictionary<string, InventoryItemGroupsRow>();
    }

    public static async Task<InventoryItemGroupsTables> CreateAsync(IPage page)
    {
        InventoryItemGroupsTables iigt = new InventoryItemGroupsTables(page);
        await iigt.InitializeTable();
        return iigt;
    }
    public async Task InitializeTable()
    {
        this.ItemsTable = new Dictionary<string, InventoryItemGroupsRow>();

        try
        {
            //Wait is required to verify table is empty, otherwise automation loads faster than webpage and will always return empty
            //Wait 3 seconds
            await this.TableLocator().WaitForAsync(new LocatorWaitForOptions { Timeout = 3000 });//this wait is required, otherwise table doesn't populate, loads too fast
        }
        catch (TimeoutException)
        {
            //When table locator finds nothing, table is empty
            return;
        }

        var rowList = await this.TableLocator().Locator("tbody tr").AllAsync();

        foreach (var rowLocator in rowList)
        {
            string? s = await rowLocator.TextContentAsync();
            if (!s.Equals("No Records Found"))
            {
                InventoryItemGroupsRow iir = new InventoryItemGroupsRow(this.page);
                await iir.InitializeRow(rowLocator);

                //Used Composite Key approach, in the case row objects don't have a unique attribute to identify a row
                string compositeKey = iir.CompositeKey();
                this.ItemsTable.Add(compositeKey, iir);
            }
        }
    }

    public InventoryItemGroupsRow GetTableValue(string key)
    {
        return this.ItemsTable[key];
    }

    public int GetTableCount()
    {
        return this.ItemsTable.Count;
    }
}