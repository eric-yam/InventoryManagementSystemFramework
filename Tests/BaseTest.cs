using Microsoft.Playwright.NUnit;

namespace PlaywrightPractice.Tests
{
    public class BaseTest : PageTest
    {
        [SetUp]

        public async Task Setup()
        {

            var webAppUrl = TestContext.Parameters["webAppUrl"];
            await Page.GotoAsync(webAppUrl);
        }

        [TearDown]
        public async Task Teardown()
        {
            await Page.CloseAsync();
        }
    }
}