import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Arm } from '../models/arm';
import { environment } from 'src/env/environment';
import { Observable } from 'rxjs';
import { ArmElbowEnum } from '../helpers/arm-elbow-enum';
import { ArmPulseEnum } from '../helpers/arm-pulse-enum';

@Injectable({
    providedIn: 'root'
})
export class ArmService {

    constructor(private http: HttpClient) {

    }

    getArmStatus(direction: string): Observable<Arm> {
        return this.http.get<Arm>(environment.apiUrl + '/home/GetArmStatus?armDirection=' + direction);
    }

    riseElbow(direction: string) {
        let body = JSON.stringify(direction);
        const httpOptions = {
            headers: new HttpHeaders({ 'Content-Type': 'application/json' })
        }
        return this.http
            .post<ArmElbowEnum>(environment.apiUrl + '/elbow/RiseArmElbow', body, httpOptions);
    }

    descendElbow(direction: string) {
        let body = JSON.stringify(direction);
        const httpOptions = {
            headers: new HttpHeaders({ 'Content-Type': 'application/json' })
        }
        return this.http
            .post<ArmElbowEnum>(environment.apiUrl + '/elbow/DescendArmElbow', body, httpOptions);
    }

    rotateMinusPulse(direction: string) {
        let body = JSON.stringify(direction);
        const httpOptions = {
            headers: new HttpHeaders({ 'Content-Type': 'application/json' })
        }
        return this.http
            .post<ArmPulseEnum>(environment.apiUrl + '/pulse/RotateMinusPulse', body, httpOptions);
    }

    rotatePlusPulse(direction: string) {
        let body = JSON.stringify(direction);
        const httpOptions = {
            headers: new HttpHeaders({ 'Content-Type': 'application/json' })
        }
        return this.http
            .post<ArmPulseEnum>(environment.apiUrl + '/pulse/RotatePlusPulse', body, httpOptions);
    }
}