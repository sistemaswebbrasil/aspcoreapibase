using System;
using System.Linq;
using Base.Controllers;
using Base.Models;
using Base.Services;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace BaseTests
{
    public class RoleControllerTest
    {
        RoleController _controller;
        IRoleService _service;

        public RoleControllerTest()
        {
            _service = new RoleServiceFake();
            _controller = new RoleController(_service);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetRoles();

            // Assert
            Assert.IsType<Role>(okResult.ToArray()[0]);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.GetRoles();

            // Assert
            Assert.True(okResult.Count() > 0);
        }
    }
}
