using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace xUnitSeleniumExamples.Sample1
{
    public class HMB_Contact_Test
    {
        [Fact]
        public void HMB_Contact_Success()
        {
            //Create a new instance of Selenium Web Driver
            IWebDriver webDriver = new ChromeDriver();
            //Navigate to the URL
            webDriver.Navigate().GoToUrl("https://www.homemovebox.com/");

            webDriver.Manage().Window.Maximize();
            Thread.Sleep(2000);

            //Find the Login link and click the Login link
            IWebElement liContactItem = webDriver.FindElement(By.Id("menu-item-51086"));

            IWebElement contactLink = liContactItem.FindElement(By.TagName("a"));
            contactLink.Click();

            //Find the UserName text box and typing on the textUserName
            IWebElement txtUserName = webDriver.FindElement(By.Name("your-name"));
            txtUserName.SendKeys("fake name");

            IWebElement txtCompany = webDriver.FindElement(By.Name("your-company"));
            txtCompany.SendKeys("13ten");

            IWebElement txtEmail = webDriver.FindElement(By.Name("your-email"));
            txtEmail.SendKeys("mycompany@hotmail.com");


            IWebElement txtPhone = webDriver.FindElement(By.Name("your-phone"));
            txtPhone.SendKeys("0987654312");

            IWebElement txtMessage = webDriver.FindElement(By.Name("your-message"));
            txtMessage.SendKeys("You have been hacked!!!");


            //Identify the Login Button and Click login button
            //IWebElement btnLogin = webDriver.FindElement(By.ClassName("button seventhly"));
            //btnLogin.Submit();
        }
    }
}
