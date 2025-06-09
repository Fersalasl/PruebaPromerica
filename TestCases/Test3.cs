using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
using Prueba;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace PruebasUI
{
    [TestClass]
    public class CapturaPantallaTests
    {
        private IWebDriver driver;
       
        [TestInitialize]
        public void Setup()
        {
            
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
   

        }
     
              

        [TestMethod]
        public void TomarCapturaDePantalla()
        {
            driver.Navigate().GoToUrl("https://www.clubpromerica.com/costarica/promociones-y-descuentos");
            Thread.Sleep(5000);

            // Tomar captura
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();

            //  donde guardar la imagen
            string nombreArchivo = $"Captura_{DateTime.Now:yyyyMMdd_HHmmss}.png";
            string rutaCompleta = Path.Combine(TestContext.TestRunDirectory, nombreArchivo);
            screenshot.SaveAsFile("captura.png");

            Console.WriteLine($"Captura guardada en: {rutaCompleta}");

            // validaciones 
            Assert.IsTrue(File.Exists(rutaCompleta), "La captura de pantalla no fue guardada correctamente.");
                     
        }
       
        

        [TestCleanup]
        public void Teardown()
        {
            driver.Quit();
        }

        public TestContext TestContext { get; set; }
    }
}
