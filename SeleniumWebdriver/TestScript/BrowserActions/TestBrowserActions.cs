using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.TestScript.BrowserActions
{
    [TestClass]
    public class TestBrowserActions
    {
        [TestMethod]
        public void TestActions()
        {
            NavigationHelper.NavigateToUrl("https://www.udemy.com/course/bdd-with-selenium-webdriver-and-speckflow-using-c/");
            ObjectRepository.Driver.Manage().Window.Maximize();
            ButtonHelper.ClickButton(By.XPath("//button[@class='course-cta btn btn-lg btn-secondary btn-block']"));
            BrowserHelper.GoBack();
            BrowserHelper.Forward();
            BrowserHelper.RefreshPage();


        }
    }
}
