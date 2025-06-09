using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.IO;
using System.Reflection;

namespace Prueba
{
    [TestClass]
    public class BaseTest
    {
        protected IWebDriver driver;
        protected static ExtentReports extent;
        protected static ExtentTest test;

        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void Setup()
        {

            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();


        }

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            string reportPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "TestReport.html");
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        [TestInitialize]
        public void TestInit()
        {
            test = extent.CreateTest(TestContext.TestName);
            driver = DriverFactory.CreateDriver(); // Asegúrate de tener esta clase implementada correctamente
        }

        [TestMethod]
        public void TomarCapturaDePantalla()
        {
            driver.Navigate().GoToUrl("https://www.clubpromerica.com/costarica/promociones-y-descuentos");
            Thread.Sleep(5000);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            var testStatus = TestContext.CurrentTestOutcome;

            if (testStatus != UnitTestOutcome.Passed)
            {
                string screenshotPath = Captura.TakeScreenShot(driver);
                if (!string.IsNullOrEmpty(screenshotPath))
                {
                    test.Fail("Test fallido").AddScreenCaptureFromPath(screenshotPath);
                }
                else
                {
                    test.Fail("Test fallido (no se pudo generar captura)");
                }
            }
            else
            {
                test.Pass("Test exitoso");
            }

            driver.Quit();
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            extent.Flush(); // Guarda el reporte al final
        }
    }
    public static class Captura
    {
        private static string DirectoryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public static string TakeScreenShot(IWebDriver driver)
        {
            try
            {
                long timestamp = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                string fileName = $"screenshot_{timestamp}.png";
                string imagePath = Path.Combine(DirectoryPath, fileName);

                Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                screenshot.SaveAsFile("captura.png");


                return imagePath;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al capturar pantalla: " + ex.Message);
                return null;
            }
        }
    }


    [TestClass]
    public class GoogleTests : BaseTest
    {
        [TestMethod]
        public void OpenGoogleTest()
        {
            driver.Navigate().GoToUrl("https://www.clubpromerica.com/costarica/comercios-2");
            Assert.IsTrue(driver.Title.Contains("COMERCIOS"));
        }
    }
}
