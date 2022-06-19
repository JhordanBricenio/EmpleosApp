using EmpleosApp.Controllers;
using EmpleosApp.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleosAppTest.Controllers
{
    public class EmailControllerTest
    {

        [Test]
        public void TestIndex01()
        {

            var mockService = new Mock<IMailService>();
            
            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
                tempData["SuccessMessage"] = "admin";

            var controller = new MailController(mockService.Object)
            {
                TempData = tempData
            };
            var result = controller.Index("hotmial", "jhordan", "hola", "hola mundo");
            
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<RedirectToActionResult>(result);
        }
    }
}
