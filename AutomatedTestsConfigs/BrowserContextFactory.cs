using AutomatedTestsConfigs.Models;
using Microsoft.Playwright;

namespace AutomatedTestsConfigs
{
    public static class BrowserContextFactory
    {
        public static async Task<IBrowserContext> GetBrowserContext(AppSettings appSettings)
        {
            switch (appSettings.TestEnvironment)
            {
                case TestEnvironments.Chrome:
                    return await GetChromeBrowserContext();
                case TestEnvironments.Firefox:
                    return await GetFirefoxBrowserContext();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static async Task<IBrowserContext> GetChromeBrowserContext()
        {
            var playwrightDriver = await Playwright.CreateAsync();

            var browserOption = new BrowserTypeLaunchOptions
            {
                Headless = false,
            };

            var chrome = await playwrightDriver.Chromium.LaunchAsync(browserOption);

            var browserContext = await chrome.NewContextAsync();

            return browserContext;
        }

        private static async Task<IBrowserContext> GetFirefoxBrowserContext()
        {
            var playwrightDriver = await Playwright.CreateAsync();

            var browserOption = new BrowserTypeLaunchOptions
            {
                Headless = false,
            };

            var chrome = await playwrightDriver.Firefox.LaunchAsync(browserOption);

            var browserContext = await chrome.NewContextAsync();

            return browserContext;
        }
    }
}