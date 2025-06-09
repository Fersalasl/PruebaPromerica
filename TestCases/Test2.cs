using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace Prueba
{
    


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
                driver = new EdgeDriver(options);
            }

            [TestMethod]
            public void OpenGoogleTest()
            {
                
                driver.Navigate().GoToUrl("https://www.clubpromerica.com/costarica/contactus");

                //ingresa nombre
                Thread.Sleep(3000);
                var nombre = driver.FindElement(By.Id("FullName"));
                nombre.SendKeys("Maria Salas");
                Assert.IsNotNull(nombre);

                //ingresa correo electronico
                //Thread.Sleep(3000);
                var correo = driver.FindElement(By.Id("Email"));
                correo.SendKeys("nandaloria27@gmail.com");
                Assert.IsNotNull(correo);

                //ingresa pregunta
                var consulta = driver.FindElement(By.Id("Enquiry"));
                consulta.SendKeys("Prueba para insercion de comentario en pag");
                Assert.IsNotNull(consulta);

                // Verifica si la página de destino contiene un mensaje de éxito
                //IWebElement resultado = driver.FindElement(By.("result"));
                //Console.WriteLine("Texto del resultado:" + resultado.Text);

                Thread.Sleep(5000);

            }

            [TestCleanup]
            public void TearDown()
            {
                driver.Quit();
            }

        }

    }





}
