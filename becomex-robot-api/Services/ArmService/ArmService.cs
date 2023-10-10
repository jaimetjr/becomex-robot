using becomex_robot_api.Helpers;

namespace becomex_robot_api.Services.ArmService
{
    public class ArmService : IArmService
    {
        public ElbowEnum DescendElbow(ElbowEnum currentState)
        {
            switch (currentState)
            {
                case ElbowEnum.Rest:
                    throw new Exception("Ação invalida");
                case ElbowEnum.SlightlyContracted:
                    return ElbowEnum.Rest;
                case ElbowEnum.Contracted:
                    return ElbowEnum.SlightlyContracted;
                case ElbowEnum.StronglyContracted:
                    return ElbowEnum.Contracted;
                default:
                    throw new Exception("Ação invalida");
            }
        }

        public ElbowEnum RiseElbow(ElbowEnum currentState)
        {
            switch (currentState)
            {
                case ElbowEnum.Rest:
                    return ElbowEnum.SlightlyContracted;
                case ElbowEnum.SlightlyContracted:
                    return ElbowEnum.Contracted;
                case ElbowEnum.Contracted:
                    return ElbowEnum.StronglyContracted;
                case ElbowEnum.StronglyContracted:
                    throw new Exception("Ação invalida");
                default:
                    throw new Exception("Ação invalida");
            }
        }

        public PulseEnum RotateMinusPulse(PulseEnum currentState)
        {
            switch (currentState)
            {
                case PulseEnum.RotationMinus90:
                    throw new Exception("Ação invalida");
                case PulseEnum.RotationMinus45:
                    return PulseEnum.RotationMinus90;
                case PulseEnum.Rest:
                    return PulseEnum.RotationMinus45;
                case PulseEnum.RotationPlus45:
                    return PulseEnum.Rest;
                case PulseEnum.RotationPlus90:
                    return PulseEnum.RotationPlus45;
                case PulseEnum.RotationPlus135:
                    return PulseEnum.RotationPlus90;
                case PulseEnum.RotationPlus180:
                    return PulseEnum.RotationPlus135;
                default:
                    throw new Exception("Ação invalida");
            }
        }

        public PulseEnum RotatePlusPulse(PulseEnum currentState)
        {
            switch (currentState)
            {
                case PulseEnum.RotationMinus90:
                    return PulseEnum.RotationMinus45;
                case PulseEnum.RotationMinus45:
                    return PulseEnum.Rest;
                case PulseEnum.Rest:
                    return PulseEnum.RotationPlus45;
                case PulseEnum.RotationPlus45:
                    return PulseEnum.RotationPlus90;
                case PulseEnum.RotationPlus90:
                    return PulseEnum.RotationPlus135;
                case PulseEnum.RotationPlus135:
                    return PulseEnum.RotationPlus180;
                case PulseEnum.RotationPlus180:
                    throw new Exception("Ação invalida");
                default:
                    throw new Exception("Ação invalida");

            }
        }
    }
}
