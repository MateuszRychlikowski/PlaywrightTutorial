using Microsoft.Playwright;

namespace PlaywrightPractice
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class Tests : BaseTest
    {
        [Test]
        public async Task HomepageHasPlaywrightInTitleAndGetStartedLinkLinkingtoTheIntroPage()
        {
            await Page.ClickAsync("id=loginLink");
        }
    }
}