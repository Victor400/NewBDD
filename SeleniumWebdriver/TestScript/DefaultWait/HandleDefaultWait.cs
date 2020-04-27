using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.TestScript.DefaultWait
{
    [TestClass]
   public class HandleDefaultWait
    {
        [TestMethod]
        public void TestDefaultWait()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            LinkHelper.ClickLink(By.LinkText("File a Bug"));
            TextBoxHelper.TypeInTextBox(By.Id("Bugzilla_login"), ObjectRepository.Config.GetUsername());
            TextBoxHelper.TypeInTextBox(By.Id("Bugzilla_password"), ObjectRepository.Config.GetPassword());
            ButtonHelper.ClickButton(By.Id("log_in"));
            ObjectRepository.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1));

            GenericHelper.WaitForWebElement(By.Id("bug_severity"), TimeSpan.FromSeconds(50));
            GenericHelper.WaitForWebElementInPage(By.Id("bug_severity"), TimeSpan.FromSeconds(50));


            DefaultWait<IWebElement> wait = new DefaultWait<IWebElement>(ObjectRepository.Driver.FindElement(By.Id("bug_severity")));
            wait.PollingInterval = TimeSpan.FromMilliseconds(200);
            wait.Timeout = TimeSpan.FromSeconds(50);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            Console.WriteLine("After wait: {0}", wait.Until(changeofValue()));

        }
        private Func<IWebElement, string> changeofValue()
        {
            return ((x) =>
            {
                Console.WriteLine("Waiting For Value To Change");
                SelectElement select = new SelectElement(x);
                if (select.SelectedOption.Text.Equals("critical")) ;
                return null;
            });
        }

 

    }
}
