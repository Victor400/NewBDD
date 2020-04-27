using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;

using OpenQA.Selenium.Firefox;
using System.Configuration;
using SeleniumWebdriver.Configuration;
using SeleniumWebdriver.Interface;

namespace SeleniumWebdriver
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestMethod1()
        {
            Console.WriteLine("Test");
        }
    }
}
