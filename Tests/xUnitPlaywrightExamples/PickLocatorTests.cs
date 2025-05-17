using Microsoft.Playwright;

namespace xUnitPlaywrightExamples;

public class PickLocatorTests
{

    [Fact]
    public async Task GeneratedLocatorTest()
    {

        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
        });
        var context = await browser.NewContextAsync();

        var page = await context.NewPageAsync();
        await page.GotoAsync("https://www.bbc.co.uk/");
        await page.GetByRole(AriaRole.Link, new() { Name = "Hamas says new Gaza talks" }).ClickAsync();
        await page.GetByTestId("reject-button").ClickAsync();
        await page.Locator("#product-navigation-menu").GetByRole(AriaRole.Link, new() { Name = "World" }).ClickAsync();
        await page.GetByRole(AriaRole.Link, new() { Name = "Eurovision final 2025: Catch" }).ClickAsync();


        await browser.CloseAsync();


    }


}
