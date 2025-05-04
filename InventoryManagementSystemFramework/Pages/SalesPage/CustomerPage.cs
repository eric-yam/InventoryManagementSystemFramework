using InventoryManagementSystemFramework.Pages;
using Microsoft.Playwright;

public class CustomerPage : BasePage
{
    private InventoryManagementTable table;
    public CustomerPage(IPage page) : base(page)
    {
        this.table = new InventoryManagementTable(page, TableRowFactory.CreateCustomerRow);
    }

    public static async Task<CustomerPage> CreateAsync(IPage page)
    {
        CustomerPage customerPage = new CustomerPage(page);
        await customerPage.table.InitializeTable();
        return customerPage;
    }

    public TableRow GetTableValue(string key)
    {
        return this.table.GetTableValue(key);
    }
}