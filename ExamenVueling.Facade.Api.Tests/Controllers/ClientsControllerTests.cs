using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExamenVueling.Facade.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Xml;
using OpenQA.Selenium.Firefox;
using ExamenVueling.Application.Dto;

namespace ExamenVueling.Facade.Api.Controllers.Selenium.Tests
{
    [TestClass()]
    public class ClientsControllerTests
    {
        public IWebDriver browser;

        [TestInitialize()]
        public void ClientsControllerTest()
        {
            //chrome = new ChromeDriver();
            browser = new FirefoxDriver();
            browser.Manage().Window.Maximize();
        }


        // GET: api/Clients
        [TestMethod()]
        public void GetAllTest()
        {
            List<ClientsDto> listado = new List<ClientsDto>();
            
            // Apartado Selenium
            browser.Navigate().GoToUrl("http://localhost:60480/api/Clients");

            var responseElement = browser.FindElements(By.TagName("ClientsDto"));

            foreach (var n in responseElement)
            {
                var nombre = n.FindElement(By.TagName("nombre"));
                var email = n.FindElement(By.TagName("email"));
                var id = n.FindElement(By.TagName("id"));
                var role = n.FindElement(By.TagName("role"));

                ClientsDto client = new ClientsDto(id.ToString(), nombre.ToString(), email.ToString(), role.ToString());
                listado.Add(client);
            }

            Assert.IsTrue(listado != null);
        }


        // GET api/Clients/id/{id}
        [TestMethod()]
        public void GetByIdTest()
        {
            Assert.Fail();
        }


        // GET api/Clients/name/{name}
        [TestMethod()]
        public void GetByNameTest()
        {
            Assert.Fail();
        }
    }
}