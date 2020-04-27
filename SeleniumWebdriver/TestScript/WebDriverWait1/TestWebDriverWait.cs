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

namespace SeleniumWebdriver.TestScript.WebDriverWait1
{
    [TestClass]
    public class TestWebDriverWait
    {
        [TestMethod]
        public void TestWait()
        {
            
            NavigationHelper.NavigateToUrl("https://www.amazon.co.uk/");

            TextBoxHelper.TypeInTextBox(By.XPath("//input[@id='twotabsearchtextbox']"), "automation testing");

        }

        [TestMethod]
        public void TestDynamicWait()
        {
            NavigationHelper.NavigateToUrl("https://www.amazon.co.uk/");

            ObjectRepository.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1));
            WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, TimeSpan.FromSeconds(50));
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));

            wait.Until(waitforSearchbox());
        }

        [TestMethod]
        public void TestExpectedCondition()
        {

            NavigationHelper.NavigateToUrl("https://www.amazon.co.uk/");

            ObjectRepository.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1));
            WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, TimeSpan.FromSeconds(50));
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//input[@id='twotabsearchtextbox']")));
           
        }

        private Func<IWebDriver, bool> waitforSearchbox()
        {
            return ((x) =>
            {
                Console.WriteLine("Waiting For Search Box");
                return x.FindElements(By.XPath("//input[@id='twotabsearchtextbox']")).Count == 1;
            });
            }
        }

    }

