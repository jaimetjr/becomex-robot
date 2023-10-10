using becomex_robot_api.Services.HeadService;
using becomex_robot_api.Helpers;

namespace becomex_robot_tests
{
    public class HeadServiceTests
    {
        [Fact]
        public void CasoInclinicaoForParaBaixoQuandoExtiverDownDarException()
        {
            var headService = new HeadService();
            Assert.Throws<Exception>(() =>
            {
                headService.HeadDown(HeadInclinationEnum.Down);
            });
        }

        [Fact]
        public void CasoInclinicaoForParaCimaQuandoJaEstiverUpDarException()
        {
            var headService = new HeadService();
            Assert.Throws<Exception>(() =>
            {
                headService.HeadUp(HeadInclinationEnum.Up);
            });
        }


        [Fact]
        public void CasoRotacaoMaisFor90GrausDarException()
        {
            var headService = new HeadService();
            Assert.Throws<Exception>(() =>
            {
                headService.HeadRotationPlus(HeadRotationEnum.RotationPlus90);
            });
        }

        [Fact]
        public void CasoRotacaoMenosFor90GrausDarException()
        {
            var headService = new HeadService();
            Assert.Throws<Exception>(() =>
            {
                headService.HeadRotationMinus(HeadRotationEnum.RotationMinus90);
            });
        }
    }
}
