using becomex_robot_api.Controllers;
using becomex_robot_api.Models;
using becomex_robot_api.Services.HeadService;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace becomex_robot_tests
{
    public class HeadControllerTests
    {

        [Fact]
        public void HeadInclinationTiverDirecaoInvalida()
        {
            var _memory = new MemoryCache(new MemoryCacheOptions());
            var controller = new HeadController(_memory, new Mock<IHeadService>().Object);

            var inclination = controller.HeadInclination("test") as Microsoft.AspNetCore.Mvc.BadRequestObjectResult;
            Assert.Equal("Direção inválida", inclination?.Value);
        }


        [Fact]
        public void HeadRotationTiverDirecaoInvalida()
        {
            var _memory = new MemoryCache(new MemoryCacheOptions());
            var controller = new HeadController(_memory, new Mock<IHeadService>().Object);

            var inclination = controller.HeadRotation("test") as Microsoft.AspNetCore.Mvc.BadRequestObjectResult;
            Assert.Equal("Direção inválida", inclination?.Value);
        }
    }
}
