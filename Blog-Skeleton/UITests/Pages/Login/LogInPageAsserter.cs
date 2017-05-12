using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITests.Pages.Login
{
    public static class LogInPageAsserter
    {
        public static void AssertLogInPageIsOpen(this LogInPage page, string text)
        {
            Assert.AreEqual(text, page.Header.Text);
        }

        public static void AssertValidLogIn1(this LogInPage page, string text)
        {
            Assert.IsTrue(page.Hello.Displayed);
            StringAssert.Contains(text, page.Hello.Text);
        }

        public static void AssertValidLogIn2(this LogInPage page, string text)
        {
            Assert.IsTrue(page.LogOff.Displayed);
            StringAssert.Contains(text, page.LogOff.Text);
        }

        public static void AssertNoEmailAddressDetected(this LogInPage page, string text)
        {
            Assert.IsTrue(page.NoEmailAddressOrInvalidEmailAddressFormat.Displayed);
            StringAssert.Contains(text, page.NoEmailAddressOrInvalidEmailAddressFormat.Text);
        }

        public static void AssertInvalidEmailAddressFormat(this LogInPage page, string text)
        {
            Assert.IsTrue(page.NoEmailAddressOrInvalidEmailAddressFormat.Displayed);
            StringAssert.Contains(text, page.NoEmailAddressOrInvalidEmailAddressFormat.Text);
        }

        public static void AssertInvalidLogInAttemptEmailAndOrPassword(this LogInPage page, string text)
        {
            Assert.IsTrue(page.InvalidLogInAttempt.Displayed);
            StringAssert.Contains(text, page.InvalidLogInAttempt.Text);
        }

        public static void AssertNoPassword(this LogInPage page, string text)
        {
            Assert.IsTrue(page.PasswordFieldRequired.Displayed);
            StringAssert.Contains(text, page.PasswordFieldRequired.Text);
        }

    }
}
