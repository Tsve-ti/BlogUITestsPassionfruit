using NUnit.Framework;
using NUnit.Framework.Internal;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using UITests.Pages.Login;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Drawing;
using UITests.Models;
using static UITests.Pages.BasePage;
using OpenQA.Selenium.Firefox;

namespace UITests
{
    [TestFixture]
    public class TestClass
    {

        public IWebDriver driver;

        [SetUp]
        public void Init()
        {
            this.driver = BrowserHost.Instance.Application.Browser;
            this.driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void CleanUp()
        {


            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                //var regPage = new RegistrationPage(driver);
                //regPage.ZoomOut();

                string filename = Environment.CurrentDirectory + ConfigurationManager.AppSettings["Logs"] + TestContext.CurrentContext.Test.Name + ".jpg";

                var screenshot = ((ITakesScreenshot)this.driver).GetScreenshot();

                screenshot.SaveAsFile(filename, ScreenshotImageFormat.Jpeg);

            }
   
        }

        [Test, Property("Priority", 1)]
        [Author("Anonymous")]
        public void ValidLogIn()
        {

            //IWebDriver driver = BrowserHost.Instance.Application.Browser;
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

            var loginPage = new LogInPage(this.driver);
            var logIn = AccessExcelData.GetTestData("ValidLogin");
            loginPage.NavigatetoBlogLogIn();
            loginPage.FillLogInForm(logIn);
            loginPage.AssertValidLogIn1(("Hello"));
            loginPage.AssertValidLogIn2("Log off");
        }

        [Test, Property("Priority", 1)]
        [Author("Anonymous")]
        public void TryToLogInNoEmailAddress()
        {
            var loginPage = new LogInPage(this.driver);
            var logIn = AccessExcelData.GetTestData("No Email Address");
            loginPage.NavigatetoBlogLogIn();
            loginPage.FillLogInForm(logIn);
            loginPage.AssertNoEmailAddressDetected("The Email field is required");
        }

        [Test, Property("Priority", 1)]
        [Author("Anonymous")]
        public void TryToLogInIncorrectEmailAddress()
        {
            var loginPage = new LogInPage(this.driver);
            var logIn = AccessExcelData.GetTestData("Incorrect Email Address");
            loginPage.NavigatetoBlogLogIn();
            loginPage.FillLogInForm(logIn);
            loginPage.AssertInvalidLogInAttemptEmailAndOrPassword("Invalid login attempt");
        }

        [Test, Property("Priority", 1)]
        [Author("Anonymous")]
        public void TryToLogInInvalidEmailAddressFormat()
        {
            var loginPage = new LogInPage(this.driver);
            var logIn = AccessExcelData.GetTestData("Invalid Email Address Format");
            loginPage.NavigatetoBlogLogIn();
            loginPage.FillLogInForm(logIn);
            loginPage.AssertInvalidEmailAddressFormat("The Email field is not a valid e-mail address");
        }

        [Test, Property("Priority", 1)]
        [Author("Anonymous")]
        public void TryToLogInIncorrectPassword()
        {
            var loginPage = new LogInPage(this.driver);
            var logIn = AccessExcelData.GetTestData("Incorrect Password");
            loginPage.NavigatetoBlogLogIn();
            loginPage.FillLogInForm(logIn);
            loginPage.AssertInvalidLogInAttemptEmailAndOrPassword("Invalid login attempt");
        }

        [Test, Property("Priority", 1)]
        [Author("Anonymous")]
        public void TryToLogInNoPassword()
        {
            var loginPage = new LogInPage(this.driver);
            var logIn = AccessExcelData.GetTestData("No Password");
            loginPage.NavigatetoBlogLogIn();
            loginPage.FillLogInForm(logIn);
            loginPage.AssertNoPassword("The Password field is required");
        }

        [Test, Property("Priority", 1)]
        [Author("Anonymous")]
        public void TryToLogInNoEmailAdressAndNoPassword()
        {
            var loginPage = new LogInPage(this.driver);
            var logIn = AccessExcelData.GetTestData("No email address and no password");
            loginPage.NavigatetoBlogLogIn();
            loginPage.FillLogInForm(logIn);
            loginPage.AssertNoEmailAddressDetected("The Email field is required");
            loginPage.AssertNoPassword("The Password field is required");
        }

        [Test, Property("Priority", 1)]
        [Author("Anonymous")]
        public void TryToLogInInvalidEmailAdressFormatAndNoPassword()
        {
            var loginPage = new LogInPage(this.driver);
            var logIn = AccessExcelData.GetTestData("Invalid email address format and no password");
            loginPage.NavigatetoBlogLogIn();
            loginPage.FillLogInForm(logIn);
            loginPage.AssertInvalidEmailAddressFormat("The Email field is not a valid e-mail address");
            loginPage.AssertNoPassword("The Password field is required");
        }

    }
}
