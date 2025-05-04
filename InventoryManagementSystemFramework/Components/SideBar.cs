using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework.Legacy;

public class SideBar : BaseComponent
{
    //Locates all Navigation links from side bar(including the ones in collapsed view)
    private ILocator NavLinks() => this.page.Locator("div[id='main-nav-tab'] a[id*='ember'][class$='nav-link'], div[id='main-nav-tab']  a[id*='ember'][class$='nav-link ']");

    private Dictionary<string, ILocator> sideBarLocatorsDictionary;

    public SideBar(IPage page) : base(page)
    {
        this.sideBarLocatorsDictionary = new Dictionary<string, ILocator>();
    }

    public async Task SetNavLinkNames()
    {
        this.sideBarLocatorsDictionary.Clear();
        char[] charsToRemove = { ' ', '\n' };
        var navigationLinks = await this.NavLinks().AllAsync();

        foreach (var locator in navigationLinks)
        {
            string? s = await locator.TextContentAsync();
            if (s != null)
            {
                string result = s.Trim(charsToRemove);
                sideBarLocatorsDictionary.Add(result, locator);
            }
        }
    }

    public async Task ClickNavSideBar(string navLink)
    {
        //the locators shift after selecting a sidebar item, requires refreshing dictionary
        await this.SetNavLinkNames();
        await this.sideBarLocatorsDictionary[navLink].ClickAsync();

    }

}