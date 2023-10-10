using becomex_robot_api.Helpers;

namespace becomex_robot_api.Services.HeadService
{
    public interface IHeadService
    {
        HeadInclinationEnum HeadUp(HeadInclinationEnum currentState);
        HeadInclinationEnum HeadDown(HeadInclinationEnum currentState);
        HeadRotationEnum HeadRotationPlus(HeadRotationEnum currentState);
        HeadRotationEnum HeadRotationMinus(HeadRotationEnum currentState);

    }
}
