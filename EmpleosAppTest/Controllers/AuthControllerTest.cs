using EmpleosApp.Controllers;
using EmpleosApp.Repositorio;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleosAppTest.Controllers
{
    public class AuthControllerTest
    {
        [Test]
        public void LoginInCorrectoTest01()
        {
            var mock = new Mock<IAuthRepositorio>();
                mock.Setup(x => x.aunteticacionCokie("admin", "admin")).Returns(false);
            var authController = new AuthController(mock.Object);
            var result = authController.Login("admin", "12345");
            Assert.IsNotNull(result);

        }
    }
}
