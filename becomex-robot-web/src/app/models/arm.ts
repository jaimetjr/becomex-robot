import { ArmElbowEnum } from "../helpers/arm-elbow-enum";
import { ArmPulseEnum } from "../helpers/arm-pulse-enum";

export interface Arm {
    elbow : ArmElbowEnum;
    pulse : ArmPulseEnum;
}