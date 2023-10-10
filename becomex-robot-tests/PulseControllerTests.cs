using becomex_robot_api.Controllers;
using becomex_robot_api.Services.ArmService;
using Microsoft.Extensions.Caching.Memory;
using Moq;

namespace becomex_robot_tests
{
    public class PulseControllerTests
    {
        [Fact]
        public void RotatePlusPulseTiverDirecaoInvalida()
        {
            var _memory = new MemoryCache(new MemoryCacheOptions());
            var controller = new PulseController(_memory, new Mock<IArmService>().Object);

            var inclination = controller.RotatePlusPulse("test") as Microsoft.AspNetCore.Mvc.BadRequestObjectResult;
            Assert.Equal("Erro ao mexer pulso", inclination?.Value);
        }


        [Fact]
        public void RotateMinusPulseTiverDirecaoInvalida()
        {
            var _memory = new MemoryCache(new MemoryCacheOptions());
            var controller = new PulseController(_memory, new Mock<IArmService>().Object);

            var inclination = controller.RotateMinusPulse("test") as Microsoft.AspNetCore.Mvc.BadRequestObjectResult;
            Assert.Equal("Erro ao mexer pulso", inclination?.Value);
        }
    }
}
