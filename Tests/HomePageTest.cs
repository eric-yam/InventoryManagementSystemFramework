using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using NUnit.Framework.Legacy;
using PlaywrightPractice.Tests;
using InventoryManagementSystemFramework.Pages.HomePage;
using InventoryManagementSystemFramework.TestDataProviders;
using InventoryManagementSystemFramework.TestDataWorkflows;
using Allure.NUnit;
using Allure.NUnit.Attributes;

namespace InventoryManagementSystemFramework.Tests
{
    [AllureNUnit]
    public class HomePageTest : BaseTest
    {
        [Test]
        [AllureName("SideBar - SideBar Navigation")]
        [TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.SideBarNavDataProvider))]
        public async Task Test_SideBar_Navigation(NavBarWorkflow wf)
        {
            SideBar sb = new SideBar(Page);

            foreach (string s in wf.SideBarNav.SidebarNavSteps)
            {
                await sb.ClickNavSideBar(s);
            }
            //TODO: assert that successfully landed on page
        }

        [Test]
        [AllureName("Home Page - Verify User and Organization")]
        [TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.HomeDashBoardWorkflowDataProvider))]
        public async Task Test_HomePage_Get_User_Org(HomeDashBoardWorkflow wf)
        {
            HomePage hp = new HomePage(Page);
            Assert.That(await hp.GetCurrentUser(), Is.EqualTo(wf.HomePage.CurrentUser));
            Assert.That(await hp.GetCurrentOrg(), Is.EqualTo(wf.HomePage.CurrentOrg));

            Assert.That(wf.HomePage.QuantityInHand == await hp.GetInventorySummaryDataValue("Quantity in Hand"), Is.True);
            Assert.That(wf.HomePage.QuantityToBeReceived == await hp.GetInventorySummaryDataValue("Quantity to be Received"), Is.True);
        }
    }
}
