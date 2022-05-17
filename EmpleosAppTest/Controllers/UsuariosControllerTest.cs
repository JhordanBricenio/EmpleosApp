﻿using EmpleosApp.Controllers;
using EmpleosApp.Models;
using EmpleosApp.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleosAppTest.Controllers
{
    public class UsuariosControllerTest
    {
        [Test]
        public void IndexTest01()
        {
            var mock = new Mock<IUsuarioRepositorio>();
                mock.Setup(m => m.ObtenerTodos()).Returns(new List<Usuario>() { new Usuario() });
            var controller = new UsuariosController(mock.Object);
            var result = (ViewResult)controller.Index();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.IsInstanceOf<List<Usuario>>(result.Model);
            Assert.AreEqual(1, ((List<Usuario>)result.Model).Count);
        }

        [Test]
        public void CreateGetTest01()
        {
            var mock = new Mock<IUsuarioRepositorio>();
            var controller = new UsuariosController(mock.Object);
            var result =controller.Index();
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);

        }

    }
}