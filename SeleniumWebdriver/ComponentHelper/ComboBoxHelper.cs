using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.ComponentHelper
{
   public class ComboBoxHelper
    {
        private static  SelectElement select;

        public static void SelectElement(By Locator, int Index)
        {
            select = new SelectElement(GenericHelper.GetElement(Locator));
            select.SelectByIndex(Index);

        }

        public static void SelectElement(By Locator, String Visibletext)
        {

            select = new SelectElement(GenericHelper.GetElement(Locator));
            select.SelectByValue(Visibletext);
        }

        public static IList<string> GetAllItem(By Locator)
        {
            select = new SelectElement(GenericHelper.GetElement(Locator));
           return select.Options.Select((x) => x.Text).ToList();
        }
    }
}
