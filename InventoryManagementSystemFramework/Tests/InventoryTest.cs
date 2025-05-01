using PlaywrightPractice.Tests;

public class InventoryTests : BaseTest
{
    [Test]
    public async Task Test_Inventory_Item_Groups()
    {
        SideBar sideBar = new SideBar(Page);
        await sideBar.ClickNavSideBar("Inventory");
        await sideBar.ClickNavSideBar("Item Groups");

        InventoryItemGroupPage iigp = await InventoryItemGroupPage.CreateAsync(Page);
        await iigp.SelectDropdownOption("Inactive Item Groups");
    }

    [Test]
    public async Task Test_Inventory_Item_Adjustments()
    {
        SideBar sideBar = new SideBar(Page);
        await sideBar.ClickNavSideBar("Inventory");
        await sideBar.ClickNavSideBar("Inventory Adjustments");

        InventoryItemAdjustmentsPage iiap = await InventoryItemAdjustmentsPage.CreateAsync(Page);
    }
}