using becomex_robot_api.Helpers;

namespace becomex_robot_api.Models
{
    public class Head
    {
        public Head()
        {
            Rotation = HeadRotationEnum.Rest;
            Inclination = HeadInclinationEnum.Rest;
        }
        public HeadRotationEnum Rotation { get; set; }
        public HeadInclinationEnum Inclination { get; set; }
    }
}
