using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xUnitSeleniumExamples.Utilities;

namespace xUnitSeleniumExamples.Sample2.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _webDriver;

        public LoginPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;

        }

        IWebElement LoginLink => _webDriver.FindElement(By.Id("loginLink"));
        IWebElement TxtUser => _webDriver.FindElement(By.Name("UserName"));
        IWebElement TxtPassword => _webDriver.FindElement(By.Name("Password"));
        IWebElement BtnLogin => _webDriver.FindElement(By.ClassName("btn"));
        IWebElement LinkLogOff => _webDriver.FindElement(By.LinkText("Log off"));

        public void ClickLogin()
        {
            CustomMethods.Click(LoginLink);
        }

        public void Login(string username, string password)
        {
            CustomMethods.EnterText(TxtUser, username);
            CustomMethods.EnterText(TxtPassword, password);
            CustomMethods.Submit(BtnLogin);
        }

        public bool IsLoggedIn()
        {
            return LinkLogOff.Displayed;
        }

    }
}
