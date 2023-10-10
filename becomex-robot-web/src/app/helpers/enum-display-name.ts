import { Injectable } from "@angular/core";
import { HeadInclinationEnum } from "./head-inclination-enum";
import { HeadRotationEnum } from "./head-rotation-enum";
import { ArmElbowEnum } from "./arm-elbow-enum";
import { ArmPulseEnum } from "./arm-pulse-enum";

@Injectable({
    providedIn: 'root'
})
export class EnumDisplayName {
    
    headInclinationName(enumNumber : HeadInclinationEnum) : string {
        return HeadInclinationEnum[enumNumber];
    }

    headRotationName(enumNumber : HeadRotationEnum) : string {
        return HeadRotationEnum[enumNumber];
    }

    armElbowName(enumNumber : ArmElbowEnum) : string {
        return ArmElbowEnum[enumNumber];
    }

    armPulseName(enumNumber : ArmPulseEnum) : string {
        return ArmPulseEnum[enumNumber];
    }
}