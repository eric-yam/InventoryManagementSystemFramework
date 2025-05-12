using Allure.NUnit;
using Allure.NUnit.Attributes;
using PlaywrightPractice.Tests;

namespace InventoryManagementSystemFramework.Tests
{
    [AllureNUnit]
    public class SalesPageTest : BaseTest
    {
        [Test]
        [AllureName("Sales Page - Verify Customer Table")]
        public async Task Test_Sales_Customer_Table()
        {
            SideBar sideBar = new SideBar(Page);
            await sideBar.ClickNavSideBar("Sales");
            // await sideBar.ClickNavSideBar("Customers");
            await sideBar.ClickNavSideBar("Sales Orders");

            // CustomerPage customerPage = await CustomerPage.CreateAsync(Page);
            SalesOrderPage salesOrderPage = await SalesOrderPage.CreateAsync(Page);
            // Assert.That(customerPage.GetTableValue("Heather E. Garrett  "), !Is.Null);
            Assert.That(salesOrderPage.GetTableValue("SO-00 |Heather E. Garrett"), !Is.Null); //key might be wrong due to spacing
        }
    }
}
