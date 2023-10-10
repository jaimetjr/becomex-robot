using becomex_robot_api.Controllers;
using becomex_robot_api.Services.ArmService;
using Microsoft.Extensions.Caching.Memory;
using Moq;

namespace becomex_robot_tests
{
    public class ElbowControllerTests
    {
        [Fact]
        public void RiseArmElbowTiverDirecaoInvalida()
        {
            var _memory = new MemoryCache(new MemoryCacheOptions());
            var controller = new ElbowController(_memory, new Mock<IArmService>().Object);

            var inclination = controller.RiseArmElbow("test") as Microsoft.AspNetCore.Mvc.BadRequestObjectResult;
            Assert.Equal("Direção inválida", inclination?.Value);
        }


        [Fact]
        public void DescendArmElbowTiverDirecaoInvalida()
        {
            var _memory = new MemoryCache(new MemoryCacheOptions());
            var controller = new ElbowController(_memory, new Mock<IArmService>().Object);

            var inclination = controller.DescendArmElbow("test") as Microsoft.AspNetCore.Mvc.BadRequestObjectResult;
            Assert.Equal("Direção inválida", inclination?.Value);
        }
    }
}
