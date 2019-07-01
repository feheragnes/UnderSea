import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TamadasInfo } from '../models/tamadas';

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

  tamadas(parameter) {
    console.log(parameter);
    return this.http.post<any>(`${this.tamadasUrl}/posttamadas`, parameter);
  }

  getHarcStatusz(): Observable<any> {
    const url = `${this.tamadasUrl}/getharcstatusz`;
    return this.http.get<any>(url);
  }
}
