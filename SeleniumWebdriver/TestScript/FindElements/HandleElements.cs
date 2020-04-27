using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.TestScript.FindElements
{
    [TestClass]
   public class HandleElements
    {
        [TestMethod]
        public void GetAllElemnts()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
           IReadOnlyCollection<IWebElement> elements = ObjectRepository.Driver.FindElements(By.XPath("//input"));
            IReadOnlyCollection<IWebElement> elements2 = ObjectRepository.Driver.FindElements(By.Id("123"));
            foreach (var ele in elements)
            {
                Console.WriteLine("ID : {0}", ele.GetAttribute("id"));
            }
        }

        
    }
}
