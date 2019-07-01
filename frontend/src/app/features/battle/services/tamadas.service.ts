import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TamadasInfo, Tamadas } from '../models/tamadas';
import { Harc } from '../models/harc';

@Injectable({
  providedIn: 'root'
})
export class TamadasService {
  private tamadasUrl = environment.apiUrl + '/tamadas';

  constructor(private http: HttpClient) {}

  getTamadasInfo(): Observable<TamadasInfo> {
    const url = `${this.tamadasUrl}/gettamadasinfos`;
    return this.http.get<TamadasInfo>(url);
  }

  tamadas(parameter: Tamadas) {
    return this.http.post(`${this.tamadasUrl}/posttamadas`, parameter);
  }

  getHarcStatusz(): Observable<Harc[]> {
    const url = `${this.tamadasUrl}/getharcstatusz`;
    return this.http.get<Harc[]>(url);
  }
}
