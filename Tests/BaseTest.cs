using Microsoft.Extensions.Configuration;
using Microsoft.Playwright.NUnit;

namespace PlaywrightPractice.Tests
{
    public class BaseTest : PageTest
    {
        protected string username;
        protected string password;
        [SetUp]
        public async Task Setup()
        {

            var webAppUrl = TestContext.Parameters["webAppUrl"];
            await Page.GotoAsync(webAppUrl);

            DotNetEnv.Env.Load();
            username = Environment.GetEnvironmentVariable("ADMIN_USERNAME");
            password = Environment.GetEnvironmentVariable("ADMIN_PASSWORD");
        }

        [TearDown]
        public async Task Teardown()
        {
            await Page.CloseAsync();
        }
    }
}