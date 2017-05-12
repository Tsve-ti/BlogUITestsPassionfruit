using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITests.Models;

namespace UITests.Pages.Login
{
    public partial class LogInPage : BasePage
    {
       

        public LogInPage(IWebDriver driver)
            : base(driver)
        {
        }

        //public string URL
        //{
        //    get
        //    {
        //        return url + "registration/";
        //    }
        //}

        //public void NavigateTo()
        //{
        //    this.Driver.Navigate().GoToUrl(this.URL);
        //}
        

        public void NavigatetoBlogLogIn()
        {
            
            this.Driver.Navigate().GoToUrl(@"http://localhost:60634/Article/List");
            this.LogInLink.Click();
        }

        private void Type(IWebElement element, string text)
        {
            if (text == null)
            {

                element.SendKeys(string.Empty);
            }
            else
            {
                element.Clear();
                element.SendKeys(text);
            }

        }

        public void FillLogInForm(LogIn user)
        {
            Type(this.EmailAdress, user.EmailAddress);
            Type(this.Password, user.Password);
            this.LogInButton.Click();

        }

        public void FillLogInFormHardCode(LogIn user)
        {
            Type(this.EmailAdress, user.EmailAddress);
            Type(this.Password, user.Password);
            this.LogInButton.Click();

        }

    }
}
