using PlaywrightPractice.Tests;
using InventoryManagementSystemFramework.TestDataProviders;
using InventoryManagementSystemFramework.Pages.InventoryPage;
using InventoryManagementSystemFramework.Pages.InventoryPage.NewInvItemPage;
using InventoryManagementSystemFramework.TestDataWorkflows;
using Allure.NUnit;
using Allure.NUnit.Attributes;


namespace InventoryManagementSystemFramework.Tests
{
    [AllureNUnit]
    public class InventoryTests : BaseTest
    {
        [Test]
        [AllureName("Inventory Page - Inventory Items Page Section Navigatibioubuoygbyuguioygion")]
        [TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.NavBarWorkflowDataProvider))]
        public async Task Test_Inventory_Items(NavBarWorkflow wf)
        {
            //Scrap test
            SideBar sideBar = new SideBar(Page);
            foreach (var step in wf.SideBarNav.SidebarNavSteps)
            {
                await sideBar.ClickNavSideBar(step);
            }
            InventoryItemsPage iip = await InventoryItemsPage.CreateAsync(Page);
            await iip.ClickNewItem();
        }

        [Test]
        [AllureName("Inventory Page - Add New Item")]
        [TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.AddNewItemWorkflowDataProvider))]
        public async Task Test_Fill_New_Inv_Item(AddNewItemWorkflow wf)
        {
            SideBar sideBar = new SideBar(Page);
            foreach (var step in wf.SideBarNav.SidebarNavSteps)
            {
                await sideBar.ClickNavSideBar(step);
            }

            InventoryItemsPage iip = await InventoryItemsPage.CreateAsync(Page);
            await iip.ClickNewItem();

            NewInvItemPage niip = new NewInvItemPage(Page);
            await niip.CheckInvItemType(wf.NewInvItemPage.InventoryItemType);
            await niip.FillNameInput(wf.NewInvItemPage.Name);
            await niip.FillSKUInput(wf.NewInvItemPage.Sku);
            await niip.SelectUnit(wf.NewInvItemPage.Unit);
            await niip.FillSellPrice(wf.NewInvItemPage.SellPrice);
            await niip.FillCostPrice(wf.NewInvItemPage.CostPrice);
            await niip.ClickSaveButton();
            await iip.ClickExitItemOverview();

            iip = await InventoryItemsPage.CreateAsync(Page);
            Assert.That(iip.GetTableValue(wf.InventoryPage.AddedInvItemKey), !Is.Null);

        }

        [Test]
        [AllureName("Inventory Page - Add Item Group")]
        [TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.AddItemGroupWorkflowDataProvider))]
        public async Task Test_Inventory_Item_Groups(AddItemGroupWorkflow wf1)
        {
            SideBar sideBar = new SideBar(Page);
            await sideBar.ClickNavSideBar("Inventory");
            await sideBar.ClickNavSideBar("Item Groups");

            InventoryItemGroupPage iigp = await InventoryItemGroupPage.CreateAsync(Page);            
            await iigp.SelectDropdownOption(wf1.DropDownGroupOption);
        }

        [Test]
        [AllureName("Inventory Page - Add Item Adjustments")]
        public async Task Test_Inventory_Item_Adjustments()
        {
            SideBar sideBar = new SideBar(Page);
            await sideBar.ClickNavSideBar("Inventory");
            await sideBar.ClickNavSideBar("Inventory Adjustments");

            InventoryItemAdjustmentsPage iiap = await InventoryItemAdjustmentsPage.CreateAsync(Page);
        }
    }
}
