import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Egyseg } from '../models/egyseg';
import { SeregInfo } from '../models/orszag';

@Injectable({
  providedIn: 'root'
})
export class EgysegService {
  private egysegUrl = environment.apiUrl + '/egyseg';

  constructor(private http: HttpClient) {}

  getEgysegInfo(): Observable<Egyseg[]> {
    const url = `${this.egysegUrl}/getegyseginfos`;
    return this.http.get<Egyseg[]>(url);
  }

  buyEgyseg(parameter: SeregInfo[]) {
    console.log(parameter);
    return this.http.post(`${this.egysegUrl}/buyegysegs`, parameter);
  }
}
