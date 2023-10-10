import { Component, Input, OnInit } from '@angular/core';
import { EnumDisplayName } from 'src/app/helpers/enum-display-name';
import { Arm } from 'src/app/models/arm';
import { ArmService } from 'src/app/services/arm.service';

@Component({
  selector: 'robotArm',
  templateUrl: './arm.component.html',
  styleUrls: ['./arm.component.css']
})
export class ArmComponent implements OnInit {
  @Input()
  armDirection: string = '';
  elbowStatus: string = '';
  pulseStatus: string = ''
  error: string = '';
  constructor(private armService: ArmService,
    private armEnum: EnumDisplayName) {

  }

  ngOnInit(): void {
    this.armStatus();
  }

  private armStatus() {
    this.armService.getArmStatus(this.armDirection)
      .subscribe({
        next: (value: Arm) => {
          this.error = '';
          this.elbowStatus = this.armEnum.armElbowName(value.elbow);
          this.pulseStatus = this.armEnum.armPulseName(value.pulse);
        }
      })
  }

  relaxarCotovelo(direction: string) {
    this.armService.descendElbow(direction)
      .subscribe({
        next: () => {
          this.armStatus();
        },
        error: (err) => this.error = err.error
      })
  }

  contrairCotovelo(direction: string) {
    this.armService.riseElbow(direction)
      .subscribe({
        next: () => {
          this.armStatus();
        },
        error: (err) => this.error = err.error
      })
  }

  moverPulsoEsquerda(direction : string) {
    this.armService.rotateMinusPulse(direction)
    .subscribe({
      next: () => {
        this.armStatus();
      },
      error: (err) => this.error = err.error
    })
  }

  moverPulsoDireita(direction : string) {
    this.armService.rotatePlusPulse(direction)
    .subscribe({
      next: () => {
        this.armStatus();
      },
      error: (err) => this.error = err.error
    })
  }
}
