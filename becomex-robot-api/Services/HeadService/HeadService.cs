using becomex_robot_api.Helpers;

namespace becomex_robot_api.Services.HeadService
{
    public class HeadService : IHeadService
    {
        public HeadInclinationEnum HeadDown(HeadInclinationEnum currentState)
        {
            switch (currentState)
            {
                case HeadInclinationEnum.Up:
                    return HeadInclinationEnum.Rest;
                case HeadInclinationEnum.Rest:
                    return HeadInclinationEnum.Down;
                case HeadInclinationEnum.Down:
                    throw new Exception("Ação invalida");
                default:
                    throw new Exception("Ação invalida");
            }
        }

        public HeadRotationEnum HeadRotationMinus(HeadRotationEnum currentState)
        {
            switch (currentState)
            {
                case HeadRotationEnum.RotationMinus90:
                    throw new Exception("Ação invalida");
                case HeadRotationEnum.RotationMinus45:
                    return HeadRotationEnum.RotationMinus90;
                case HeadRotationEnum.Rest:
                    return HeadRotationEnum.RotationMinus45;
                case HeadRotationEnum.RotationPlus45:
                    return HeadRotationEnum.Rest;
                case HeadRotationEnum.RotationPlus90:
                    return HeadRotationEnum.RotationPlus45;
                default:
                    throw new Exception("Ação invalida");
            }
        }

        public HeadRotationEnum HeadRotationPlus(HeadRotationEnum currentState)
        {
            switch (currentState)
            {
                case HeadRotationEnum.RotationMinus90:
                    return HeadRotationEnum.RotationMinus45;
                case HeadRotationEnum.RotationMinus45:
                    return HeadRotationEnum.Rest;
                case HeadRotationEnum.Rest:
                    return HeadRotationEnum.RotationPlus45;
                case HeadRotationEnum.RotationPlus45:
                    return HeadRotationEnum.RotationPlus90;
                case HeadRotationEnum.RotationPlus90:
                    throw new Exception("Ação invalida");
                default:
                    throw new Exception("Ação invalida");
            }
        }

        public HeadInclinationEnum HeadUp(HeadInclinationEnum currentState)
        {
            switch (currentState)
            {
                case HeadInclinationEnum.Up:
                    throw new Exception("Ação invalida");
                case HeadInclinationEnum.Rest:
                    return HeadInclinationEnum.Up;
                case HeadInclinationEnum.Down:
                    return HeadInclinationEnum.Rest;
                default:
                    throw new Exception("Ação invalida");
            }
        }
    }
}
