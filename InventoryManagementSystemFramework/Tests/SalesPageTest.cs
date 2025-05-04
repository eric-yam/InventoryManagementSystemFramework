using PlaywrightPractice.Tests;

namespace InventoryManagementSystemFramework.Tests
{
    public class SalesPageTest : BaseTest
    {
        [Test]
        public async Task Test_Sales_Customer_Table()
        {
            SideBar sideBar = new SideBar(Page);
            await sideBar.ClickNavSideBar("Sales");
            await sideBar.ClickNavSideBar("Customers");

            CustomerPage customerPage = await CustomerPage.CreateAsync(Page);
            Assert.That(customerPage.GetTableValue("Heather E. Garrett  "), !Is.Null);

        }
    }
}
