using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.TestScript.TextBox
{
    [TestClass]
   public class TestTextBox
    {
        [TestMethod]
        public void TextBox()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            //IWebElement element =  ObjectRepository.Driver.FindElement(By.LinkText("File a Bug"));
            //   element.Click();

            //   IWebElement pelement = ObjectRepository.Driver.FindElement(By.PartialLinkText("File"));
            //   element.Click();
        
            LinkHelper.ClickLink(By.LinkText("File a Bug"));
            //IWebElement ele = ObjectRepository.Driver.FindElement(By.Id("Bugzilla_login"));
            //ele.SendKeys(ObjectRepository.Config.GetUsername());
            // ele = ObjectRepository.Driver.FindElement(By.Id("Bugzilla_password"));
            //ele.SendKeys(ObjectRepository.Config.GetPassword());
            //ele = ObjectRepository.Driver.FindElement(By.Id("Bugzilla_login"));
            //ele.Clear();

            TextBoxHelper.TypeInTextBox(By.Id("Bugzilla_login"), ObjectRepository.Config.GetUsername());
            TextBoxHelper.TypeInTextBox(By.Id("Bugzilla_password"), ObjectRepository.Config.GetPassword());
            TextBoxHelper.ClearTextBox(By.Id("Bugzilla_login"));
           
        }

    }
}
