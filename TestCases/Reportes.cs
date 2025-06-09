using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Threading;

namespace Prueba.TestCases
{
    [TestClass]
    public class CapturaPantallaTests

    {

        private IWebDriver driver;
        private static ExtentReports extent;
        private ExtentTest test;

        public TestContext TestContext { get; set; }

        [ClassInitialize]
        public static void SetupReport(TestContext context)
        {
            string reporte = @"C:\\Users\\Miguel Salas\\source\\repos\\Prueba\\Reportes";
            Directory.CreateDirectory(reporte);
            var htmlReporter = new ExtentHtmlReporter(Path.Combine(reporte, "ReporteCaptura.html"));
            //var htmlReporter = new ExtentHtmlReporter("@C:\\Users\\Miguel Salas\\source\\repos\\Prueba\\Reportes");
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        [TestInitialize]

        public void Setup()

        {

            driver = new ChromeDriver();

            driver.Manage().Window.Maximize();
            test = extent.CreateTest(TestContext.TestName);

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

            string rutaDirectorio = @"C:\Users\Miguel Salas\source\repos\Prueba\Capturas";

            string rutaCompleta = Path.Combine(rutaDirectorio, nombreArchivo);

            screenshot.SaveAsFile(rutaCompleta);

            test.Pass("Captura de pantalla tomada")
                 .AddScreenCaptureFromPath(rutaCompleta);




            // validaciones 

            Assert.IsTrue(File.Exists(rutaCompleta), "La captura de pantalla fue guardada correctamente.");

        }

        [TestCleanup]

        public void Teardown()

        {
            driver.Quit();


        }

       



    }
}
