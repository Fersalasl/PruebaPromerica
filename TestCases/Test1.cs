using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;


namespace Prueba
{

    [TestClass]
    public class EdgeTests
    {
        private IWebDriver driver;
       

        [TestInitialize]
        public void Setup()
        {
          var options = new EdgeOptions();
         // options.UseChromium = true;
          driver = new EdgeDriver(options);
        }

        [TestMethod]
        public void OpenGoogleTest()
        {
            //driver.Navigate().GoToUrl("https://www.google.com");
            //Assert.IsTrue(driver.Title.Contains("Google"));
            //Thread.Sleep(5000);
            /// ir a pagina promerica
            driver.Navigate().GoToUrl("https://www.clubpromerica.com/costarica/ ");
            Thread.Sleep(3000);
            var viajes = driver.FindElement(By.XPath("//img[contains(@class,'picture-img')]"));
            viajes.Click();

            Thread.Sleep(5000);

        }

        [TestCleanup]
        public void TearDown()
        {
            driver.Quit();
        }

    }

}
