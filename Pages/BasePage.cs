using Microsoft.Playwright;

namespace InventoryManagementSystemFramework.Pages
{
    public abstract class BasePage
    {
        public IPage page;
        public SideBar sideBar;

        public BasePage(IPage page)
        {
            this.page = page;
            this.sideBar = new SideBar(this.page);
        }
    }
}
