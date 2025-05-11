using InventoryManagementSystemFramework.Pages.InventoryPage;
using Microsoft.Playwright;

public class SalesOrderPage : InventoryManagementPage
{
    public SalesOrderPage(IPage page) : base(page) { }

    public static async Task<SalesOrderPage> CreateAsync(IPage page)
    {
        SalesOrderPage salesOrderPage = new SalesOrderPage(page);
        await salesOrderPage.table.InitializeTable();
        return salesOrderPage;
    }

    public override Func<IPage, ILocator, Task<TableRow>> GetRowFactoryMethodReference()
    {
        return TableRowFactory.CreateSalesOrderRow;
    }

}