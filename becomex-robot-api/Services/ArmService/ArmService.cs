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

        public PulseEnum DescendPulse(PulseEnum currentState)
        {
            throw new NotImplementedException();
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

        public PulseEnum RisePulse(PulseEnum currentState)
        {
            switch (currentState)
            {
                
            }
        }
    }
}
