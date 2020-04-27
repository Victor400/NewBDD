﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.TestScript.CheckBox
{
    [TestClass]
 public class TestCheckBox
    {
        [TestMethod]
        public void TestTextBox()
        {
            {
                NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
                LinkHelper.ClickLink(By.LinkText("File a Bug"));
                TextBoxHelper.TypeInTextBox(By.Id("Bugzilla_login"), ObjectRepository.Config.GetUsername());
                TextBoxHelper.TypeInTextBox(By.Id("Bugzilla_password"), ObjectRepository.Config.GetPassword());
                TextBoxHelper.ClearTextBox(By.Id("Bugzilla_login"));
                //IWebElement ele = ObjectRepository.Driver.FindElement(By.Id("Bugzilla_restrictlogin"));
                //    ele.Click();

                Console.WriteLine(CheckBoxHelper.IsCheckBoxChecked(By.Id("Bugzilla_restrictlogin")));

                CheckBoxHelper.CheckedCheckBox(By.Id("Bugzilla_restrictlogin"));

                Console.WriteLine(CheckBoxHelper.IsCheckBoxChecked(By.Id("Bugzilla_restrictlogin")));

            }
        }

    }
}


