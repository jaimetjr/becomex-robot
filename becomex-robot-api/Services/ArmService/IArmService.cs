using becomex_robot_api.Helpers;

namespace becomex_robot_api.Services.ArmService
{
    public interface IArmService
    {
        ElbowEnum RiseElbow(ElbowEnum currentState);
        ElbowEnum DescendElbow(ElbowEnum currentState);
        PulseEnum RotateMinusPulse(PulseEnum currentState);
        PulseEnum RotatePlusPulse(PulseEnum currentState);
    }
}
