using OpenQA.Selenium;
using SeleniumWebdriver.ComponentHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.PageObject
{
  public class BugDetail
    {
        #region WebElement

        private By SeverityDropDown = By.Id("bug_severity");

        #endregion

        #region Action

        public void SelectFromSeverity(string value)
        {
            ComboBoxHelper.SelectElement(SeverityDropDown, value);
        }

        #endregion
    }
}
