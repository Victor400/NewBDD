using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumWebdriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Threading.Tasks;
using SeleniumWebdriver.ComponentHelper;


namespace SeleniumWebdriver.TestScript.PageNavigation
{
    [TestClass]
   public class TestPageNavigation
    {
        [TestMethod]

        public void OpenPage()

        {
            // INavigation page = ObjectRepository.Driver.Navigate();
            // page.GoToUrl(ObjectRepository.Config.GetWebsite());

            //ObjectRepository.Driver.Navigate().GoToUrl(ObjectRepository.Config.GetWebsite());

            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());

            Console.WriteLine("Title of Page : {0}", WindowHelper.GetTitle());
            

        }
    }
}
