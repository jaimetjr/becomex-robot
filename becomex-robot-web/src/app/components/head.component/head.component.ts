import { Component, Input, OnInit } from '@angular/core';
import { HeadService } from 'src/app/services/head.service';
import { Head } from '../../models/head';
import { EnumDisplayName } from 'src/app/helpers/enum-display-name';
import { HttpErrorResponse } from '@angular/common/http';
@Component({
  selector: 'robotHead',
  templateUrl: './head.component.html',
  styleUrls: ['./head.component.css']
})
export class HeadComponent implements OnInit {
  public head: Head | null = null;
  headInclination = '';
  headRotation = '';
  error = '';
  constructor(private headService: HeadService,
    private headEnum: EnumDisplayName) {

  }

  ngOnInit() {
    this.headStatus();
  }

  private headStatus() {
    this.headService.getHeadStatus().subscribe((value: Head) => {
      this.headInclination = this.headEnum.headInclinationName(value.inclination);
      this.headRotation = this.headEnum.headRotationName(value.rotation);
    })
  }

  moveHead(direction: string) {
    this.headService.headInclination(direction)
      .subscribe({
        next: () => {
          this.error = '';
          this.headStatus();
        },
        error: (err: HttpErrorResponse) => { this.error = err.error; }
      })
  }

  rotateHead(direction: string) {
    this.headService.headRotation(direction)
      .subscribe({
        next: () => {
          this.error = '';
          this.headStatus();
        },
        error: (err: HttpErrorResponse) => { this.error = err.error; }
      })
  }
}
