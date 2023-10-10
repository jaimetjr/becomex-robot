import { HeadInclinationEnum } from "../helpers/head-inclination-enum";
import { HeadRotationEnum } from "../helpers/head-rotation-enum";

export interface Head {
    rotation : HeadRotationEnum;
    inclination : HeadInclinationEnum;
}