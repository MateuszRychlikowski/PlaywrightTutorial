using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomatedTestsConfigs;

namespace PlaywrightPractice
{
    public class BaseTest
    {
        [SetUp]
        public async Task Setup()
        {
            var browserContext = BrowserContextFactory.GetBrowserContext(ConfigManager.AppSettings).Result;
            var page = await browserContext.NewPageAsync();

            await page.GotoAsync("http://eaapp.some.com");
        }
    }
}