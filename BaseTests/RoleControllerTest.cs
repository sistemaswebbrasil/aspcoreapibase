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
        IGenericService<Role> _service;

        public RoleControllerTest()
        {
            _service = new RoleServiceFake();
            _controller = new RoleController(_service);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Index();

            // Assert
            Assert.IsType<Role>(okResult.ToArray()[0]);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.Index();

            // Assert
            Assert.True(okResult.Count() > 0);
        }


        [Fact]
        public void GetById_UnknownGuidPassed_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.Show(99);

            // Assert
            Assert.IsType<ActionResult<NotFoundObjectResult>>(notFoundResult.Result);
        }

        [Fact]
        public void GetById_ExistingGuidPassed_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Show(1);

            // Assert
            Assert.IsType<ActionResult<Role>>(okResult.Result);
        }

        [Fact]
        public void GetById_ExistingGuidPassed_ReturnsRightItem()
        {
            // Act
            var okResult = _controller.Show(1).Result as ActionResult<Role>;

            // Assert
            Assert.IsType<Role>(okResult.Value);
            Assert.Equal(1, (okResult.Value as Role).Id);
        }

    }
}
