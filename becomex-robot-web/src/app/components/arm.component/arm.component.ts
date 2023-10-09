import { Component, Input } from '@angular/core';

@Component({
  selector: 'robotArm',
  templateUrl: './arm.component.html',
  styleUrls: ['./arm.component.css']
})
export class ArmComponent {
  @Input()
  armDirection : string = '';

  
}
