using AutomatedTestsConfigs.Models;
using Microsoft.Playwright;

namespace AutomatedTestsConfigs
{
    public static class BrowserContextFactory
    {
        public static async Task<IBrowserContext> GetBrowserContext(AppSettings appSettings)
        {
            var playwrightDriver = await Playwright.CreateAsync();

            var browserOption = new BrowserTypeLaunchOptions
            {
                Headless = false,
            };

            var browser = await GetBrowser(playwrightDriver, appSettings.TestEnvironment, browserOption);

            var browserContext = await browser.NewContextAsync();

            return browserContext;
        }


        private static async Task<IBrowser> GetBrowser(IPlaywright playwrightDriver, TestEnvironments environment,
            BrowserTypeLaunchOptions browserOption)
        {
            return environment switch
            {
                TestEnvironments.Chrome => await playwrightDriver.Chromium.LaunchAsync(browserOption),
                TestEnvironments.Firefox => await playwrightDriver.Firefox.LaunchAsync(browserOption),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}