import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../env/environment';
import { Head } from '../models/head';
import { Observable } from 'rxjs';
import { HeadInclinationEnum } from '../helpers/head-inclination-enum';
import { HeadRotationEnum } from '../helpers/head-rotation-enum';

@Injectable({
    providedIn: 'root'
})
export class HeadService {

    constructor(private http: HttpClient) {

    }

    getHeadStatus(): Observable<Head> {
        return this.http.get<Head>(environment.apiUrl + '/home/GetHeadStatus');
    }

    headInclination(direction: string): Observable<HeadInclinationEnum> {
        let body = JSON.stringify(direction);
        const httpOptions = {
            headers: new HttpHeaders({ 'Content-Type': 'application/json' })
        }
        return this.http.post<HeadInclinationEnum>(environment.apiUrl + '/head/HeadInclination', body, httpOptions);
    }

    headRotation(direction: string): Observable<HeadRotationEnum> {
        let body = JSON.stringify(direction);
        const httpOptions = {
            headers: new HttpHeaders({ 'Content-Type': 'application/json' })
        }
        return this.http.post<HeadRotationEnum>(environment.apiUrl + '/head/HeadRotation',body, httpOptions);
    }
}