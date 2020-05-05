
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using SeleniumWebdriver.Configuration;
using SeleniumWebdriver.CustomException;
using SeleniumWebdriver.Settings;
using System;
using SeleniumWebdriver.ComponentHelper;

namespace SeleniumWebdriver.BaseClasses
{
    [TestClass]
    public class BaseClass
    {

        private static FirefoxProfile GetFirefoxoptions()
        {
            FirefoxProfile profile = new FirefoxProfile();
            FirefoxProfileManager manager = new FirefoxProfileManager();
            profile = manager.GetProfile("default");
            return profile;
        }

        private static ChromeOptions GetChromeOptions()
    {
            ChromeOptions Option = new ChromeOptions();
            Option.AddArgument("start-maximized");
            return Option;

      }

        private static InternetExplorerOptions GetIEOptions()
        {
            InternetExplorerOptions options = new InternetExplorerOptions();
            options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            options.EnsureCleanSession = true;
            return options;
        }
        private static IWebDriver GetFirefoxDriver()
        {
            IWebDriver driver = new FirefoxDriver();
            return driver;
        }
    
        private static IWebDriver GetChromeDriver()

        {

            IWebDriver driver = new ChromeDriver(GetChromeOptions());
            return driver;
        }

        private static IWebDriver GetIEDriver()

    {
        IWebDriver driver = new InternetExplorerDriver(GetIEOptions());
        return driver;
    }



        [AssemblyInitialize]

    public static void InitWebDriver(TestContext tc)
    {
            ObjectRepository.Config = new AppConfigReader();

            switch (ObjectRepository.Config.GetBrowser())
            {
                case BrowserType.Firefox:
                    ObjectRepository.Driver = GetFirefoxDriver();
                    break;

                case BrowserType.Chrome:
                    ObjectRepository.Driver = GetChromeDriver();
                    break;

                case BrowserType.IExplorer:
                    ObjectRepository.Driver = GetIEDriver();
                    break;

                default:
                    throw new NoSuitableDriverFound("Driver Not Found : " + ObjectRepository.Config.GetBrowser().ToString());
            }

            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            ObjectRepository.Driver.Manage()
                .Timeouts().(TimeSpan.FromSeconds(ObjectRepository.Config.GetPageLoadTimeOut()));

            ObjectRepository.Driver.Manage()
                .Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeOut()));
        }

        [AssemblyCleanup]
        public static void TearDown()
        {
            if (ObjectRepository.Driver != null)
            {
             //  ObjectRepository.Driver.Close();

             //  ObjectRepository.Driver.Quit();
            }
        }
  }
}

