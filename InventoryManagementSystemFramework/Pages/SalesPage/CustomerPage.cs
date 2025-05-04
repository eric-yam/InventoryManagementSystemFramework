using InventoryManagementSystemFramework.Pages;
using InventoryManagementSystemFramework.Pages.InventoryPage;
using Microsoft.Playwright;

public class CustomerPage : InventoryManagementPage
{
    public CustomerPage(IPage page) : base(page) { }

    public static async Task<CustomerPage> CreateAsync(IPage page)
    {
        CustomerPage customerPage = new CustomerPage(page);
        await customerPage.table.InitializeTable();
        return customerPage;
    }

    public override Func<IPage, ILocator, Task<TableRow>> GetRowFactoryMethodReference()
    {
        return TableRowFactory.CreateCustomerRow;
    }
}