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
        protected IPage? Page { get; private set; }

        [SetUp]
        public async Task Setup()
        {
            var browserContext = BrowserContextFactory.GetBrowserContext(ConfigManager.AppSettings).Result;
            Page = await browserContext.NewPageAsync();
            await Page.GotoAsync("http://eaapp.somee.com");
        }
    }
}