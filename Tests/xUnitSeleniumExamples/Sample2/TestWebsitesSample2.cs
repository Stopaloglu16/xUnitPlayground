using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using xUnitSeleniumExamples.Sample2.Pages;

namespace xUnitSeleniumExamples.Sample2
{
    public class TestWebsitesSample2
    {

        [Fact]
        public void Test_Eaapp_Login()
        {
            //Arange
            //Create a new instance of Selenium Web Driver
            IWebDriver webDriver = new ChromeDriver();
            //Navigate to the URL
            webDriver.Navigate().GoToUrl("http://eaapp.somee.com/");

            //Act
            LoginPage loginPage = new LoginPage(webDriver);
            loginPage.ClickLogin();
            loginPage.Login("admin", "password");

            //Assert
            Assert.True(loginPage.IsLoggedIn());


            webDriver.Close();

        }
    }
}
