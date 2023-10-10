using becomex_robot_api.Helpers;
using becomex_robot_api.Services.ArmService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace becomex_robot_tests
{
    public class ArmServiceTests
    {
        [Fact]
        public void CasoCotoveloBaixeAlemDoEstadoRespousoDarException()
        {
            var armService = new ArmService();
            Assert.Throws<Exception>(() =>
            {
                armService.DescendElbow(ElbowEnum.Rest);
            });
        }

        [Fact]
        public void CasoCotoveloLevanteAlemDoEstadoFortementeContraidoDarException()
        {
            var armService = new ArmService();
            Assert.Throws<Exception>(() =>
            {
                armService.RiseElbow(ElbowEnum.StronglyContracted);
            });
        }

        [Fact]
        public void CasoPulsoRotacioneAntesDeMenos90DarException()
        {
            var armService = new ArmService();
            Assert.Throws<Exception>(() =>
            {
                armService.RotateMinusPulse(PulseEnum.RotationMinus90);
            });
        }

        [Fact]
        public void CasoPulsoRotacioneDepoisDeMais180DarException()
        {
            var armService = new ArmService();
            Assert.Throws<Exception>(() =>
            {
                armService.RotatePlusPulse(PulseEnum.RotationPlus180);
            });
        }
    }
}
