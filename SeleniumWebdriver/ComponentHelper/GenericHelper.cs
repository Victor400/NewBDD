using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using SeleniumWebdriver.Settings;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.ComponentHelper
{
   public  class GenericHelper
    {

        public static bool IsElementPresent(By Locator)
        {

            try
            {
                return ObjectRepository.Driver.FindElements(Locator).Count == 1;

            }

            catch (Exception)
            {
                return false;
            }
           
        }

        public static IWebElement GetElement(By Locator)

        {
            if (IsElementPresent(Locator))
                return ObjectRepository.Driver.FindElement(Locator);

            else

                throw new NoSuchElementException("Element Not Found : " + Locator.ToString());
        }

        public static void TakeScreenShot(string filename = "screen")
        {
            Screenshot screen = ObjectRepository.Driver.TakeScreenshot();
            if (filename.Equals("screen"))
            {
                filename = filename + DateTime.UtcNow.ToString("yyyy-MM-dd-mm-ss") + ".jpeg";
                screen.SaveAsFile(filename, ImageFormat.Jpeg);
                return;
            }

            screen.SaveAsFile(filename, ImageFormat.Jpeg);

        }

        public static bool WaitForWebElement(By Locator, TimeSpan timeout)
        {
            ObjectRepository.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1));
            WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, timeout);
            wait.PollingInterval = TimeSpan.FromMilliseconds(500);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            bool flag = wait.Until(WaitForWebElementFunc(Locator));
            ObjectRepository.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeOut()));
            return flag;
        }

        public static IWebElement WaitForWebElementInPage(By Locator, TimeSpan timeout)
        {
            ObjectRepository.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1));
            WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, timeout);
            wait.PollingInterval = TimeSpan.FromMilliseconds(500);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            IWebElement flag = wait.Until(WaitForWebElementInPageFunc(Locator));
            ObjectRepository.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeOut()));
            return flag;
        }

        private static Func<IWebDriver, bool> WaitForWebElementFunc(By Locator)
        {
            return ((x) =>
            {
                if (x.FindElements(Locator).Count == 1)
                    return true;
                return false;
            });
        }
        private static Func<IWebDriver, IWebElement> WaitForWebElementInPageFunc(By Locator)
        {
            return ((x) =>
            {
                if(x.FindElements(Locator).Count == 1)
                 return x.FindElement(Locator);
                return null;
            });

        }
    }
}
