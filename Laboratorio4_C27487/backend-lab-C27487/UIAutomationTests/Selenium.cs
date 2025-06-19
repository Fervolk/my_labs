using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace UIAutomationTests
{
    public class Selenium
    {
#pragma warning disable NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method
        IWebDriver _driver;
#pragma warning restore NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
        }

        [Test]
        public void Add_New_Country_Test()
        {
            var URL = "http://localhost:8080/";
            var nombrePais = "Alemania";
            var nombreContinente = "Europa";
            var idioma = "Alem�n";
            _driver.Manage().Window.Maximize();

            _driver.Navigate().GoToUrl(URL);

            var agregarPais = _driver.FindElement(By.XPath("//a[@href='/pais']/button[contains(text(), 'Agregar pa�s')]"));
            agregarPais.Click();

            _driver.FindElement(By.Id("name")).SendKeys(nombrePais);
            var listaContinentes = new SelectElement(_driver.FindElement(By.Id("continente")));
            listaContinentes.SelectByText(nombreContinente);
            _driver.FindElement(By.Id("idioma")).SendKeys(idioma);

            _driver.FindElement(By.XPath("//button[@type='submit']")).Click();

            //Codigo de: https://www.selenium.dev/documentation/webdriver/waits/
            //Hay que esperar hasta que la lista est� cargada para poder buscar el pa�s
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));
            wait.Until(d => d.FindElement(By.XPath("//table//tbody//tr")));

            var filaAlemania = _driver.FindElement(By.XPath($"//td[contains(text(), '{nombrePais}')]"));

            //El frontend no tiene ning�n mensaje de confirmaci�n as� que verifico manualmente si el pa�s se agreg�
            Assert.IsTrue(filaAlemania.Displayed);
        }
    }
}