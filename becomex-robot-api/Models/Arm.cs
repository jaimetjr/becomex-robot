using becomex_robot_api.Helpers;

namespace becomex_robot_api.Models
{
    public class Arm
    {
        public Arm()
        {
            Elbow = ElbowEnum.Rest;
            Pulse = PulseEnum.Rest;
        }

        public ElbowEnum Elbow { get; set; }
        public PulseEnum Pulse { get; set; }
    }
}
