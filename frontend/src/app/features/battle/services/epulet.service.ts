import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Epulet } from '../models/epulet';
import { EpuletInfo } from '../models/orszag';

@Injectable({
  providedIn: 'root'
})
export class EpuletService {
  private epuletUrl = environment.apiUrl + '/epulet';

  constructor(private http: HttpClient) {}

  getEpuletInfo(): Observable<Epulet[]> {
    const url = `${this.epuletUrl}/getuserepulets`;
    return this.http.get<Epulet[]>(url);
  }

  buyEpulet(type: string) {
    const parameter: EpuletInfo = {
      tipus: type,
      ar: 1,
      mennyiseg: 1
    };
    return this.http.post(`${this.epuletUrl}/buyepulets`, [parameter]);
  }
}
