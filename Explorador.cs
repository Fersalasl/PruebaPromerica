using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace Prueba
{
  
    public class DriverFactory
    {
        [TestInitialize]
        
        public static IWebDriver CreateDriver()
        {
          
            var options = new EdgeOptions();
            options.AddArgument("start-maximized");
            return new EdgeDriver(options); 
        }

        //public static IWebDriver CreateDriverChrome()
        //{

        //    var optionsChrome = new ChromeDriver();
        //    optionsChrome.Manage().Window.Maximize();
        //    return new ChromeDriver(optionsChrome);
        //}
    }
}
