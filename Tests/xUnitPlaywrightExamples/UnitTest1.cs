using Microsoft.Playwright.Xunit;
using Microsoft.Playwright;

namespace xUnitPlaywrightExamples
{

    public class UnitTest1 : PageTest
    {
        [Fact]
        public async Task TestWithCustomContextOptions()
        {
            // The following Page (and BrowserContext) instance has the custom colorScheme, viewport and baseURL set:
            await Page.GotoAsync("/login");
        }
        public override BrowserNewContextOptions ContextOptions()
        {
            return new BrowserNewContextOptions()
            {
                ColorScheme = ColorScheme.Light,
                ViewportSize = new()
                {
                    Width = 1920,
                    Height = 1080
                },
                BaseURL = "https://github.com",
            };
        }
    }
}
