using System.Threading.Tasks;
using Microsoft.Playwright;

public class HomePage : BasePage
{
    private int CURR_USER_INDEX_INC = 1;
    private ILocator CurrentUser() => this.page.Locator("div[class='d-flex mt-3'] div[class='font-xlarge text-medium mt-3']");
    private ILocator CurrentOrg() => this.page.Locator("div[class='d-flex mt-3'] div[class='text-muted']");
    private ILocator InventorySummaryData() => this.page.Locator("div[class='inv-summary']");

    private Dictionary<string, double> InventorySummaryDictionary;
    public HomePage(IPage page) : base(page)
    {
        this.InventorySummaryDictionary = new Dictionary<string, double>();
    }

    public async Task<string> GetCurrentUser()
    {
        string s = "";
        string? result = await this.CurrentUser().TextContentAsync();

        if (result != null)
        {
            return result.Substring(result.IndexOf(" ") + CURR_USER_INDEX_INC);
        }
        else
        {
            return s;
        }
    }

    public async Task<string> GetCurrentOrg()
    {
        string s = "";
        string? result = await this.CurrentOrg().TextContentAsync();
        if (result != null)
        {
            return result;
        }
        else
        {
            return s;
        }
    }

    public async Task SetInventorySummaryData()
    {
        this.InventorySummaryDictionary.Clear();
        var tempList = await this.InventorySummaryData().AllAsync();

        foreach (var item in tempList)
        {
            string? title = await item.Locator("label").TextContentAsync();
            string? value = await item.Locator("div").TextContentAsync();

            this.InventorySummaryDictionary.Add(title, Convert.ToDouble(value));
        }
    }

    public async Task<double> GetInventorySummaryDataValue(string title)
    {
        await this.SetInventorySummaryData();
        return this.InventorySummaryDictionary[title];
    }
}