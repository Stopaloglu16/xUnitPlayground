using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace xUnitSeleniumExamples.Sample1
{
    public class TestWebsitesSample1
    {
        [Fact]
        public void Test_Google()
        {
            //Create a new instance of Selenium WebDriver
            IWebDriver webDriver = new ChromeDriver();

            //Navigate to URL
            webDriver.Navigate().GoToUrl("https://www.google.co.uk/");

            //Maximize the browser
            webDriver.Manage().Window.Maximize();

            IWebElement webElement1 = webDriver.FindElement(By.Id("W0wltc"));
            webElement1.Click();

            //Find the element
            IWebElement webElement = webDriver.FindElement(By.Name("q"));

            //Type in the element
            webElement.SendKeys("What is Selenium");

            //Click on the element
            webElement.SendKeys(Keys.Return);

            Thread.Sleep(2000);
            webDriver.Close();
        }

        [Fact]
        public void Test_Eaapp()
        {
            //Create a new instance of Selenium Web Driver
            IWebDriver webDriver = new ChromeDriver();
            //Navigate to the URL
            webDriver.Navigate().GoToUrl("http://eaapp.somee.com/");

            //Find the Login link and click the Login link
            IWebElement loginLink = webDriver.FindElement(By.Id("loginLink"));
            loginLink.Click();

            //Or Opt1
            //driver.FindElement(By.Id("loginLink")).Click();

            //Or Opt2
            //CustomMethods.Click(webDriver, By.Id("loginLink"));


            //Find the UserName text box and typing on the textUserName
            IWebElement txtUserName = webDriver.FindElement(By.Name("UserName"));
            txtUserName.SendKeys("admin");

            //Or Opt1
            //CustomMethods.EnterText(webDriver, By.Name("UserName"), "Admin");


            //Find the Password text box and typing on the textUserName
            IWebElement txtPassword = webDriver.FindElement(By.Id("Password"));
            txtPassword.SendKeys("password");

            //Identify the Login Button and Click login button
            //Or Class name with dot by CssSelector
            //IWebElement btnLogin = webDriver.FindElement(By.CssSelector(".btn")); 
            IWebElement btnLogin = webDriver.FindElement(By.ClassName("btn"));

            btnLogin.Submit();
        }

        [Fact]
        public void Test_Dropdown()
        {
            IWebDriver webDriver = new ChromeDriver();
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Sample1\\WebHtml\\selectoption.html");
            webDriver.Navigate().GoToUrl(filePath);

            SelectElement selectElement = new SelectElement(webDriver.FindElement(By.Id("cars")));
            selectElement.SelectByText("Opel");
        }

    }
}
