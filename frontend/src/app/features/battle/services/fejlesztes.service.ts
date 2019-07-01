import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Fejlesztes } from '../models/fejlesztes';

@Injectable({
  providedIn: 'root'
})
export class FejlesztesService {
  private fejlesztesUrl = environment.apiUrl + '/fejlesztes';

  constructor(private http: HttpClient) {}

  getFejlesztesInfo(): Observable<Fejlesztes[]> {
    const url = `${this.fejlesztesUrl}/getfejlesztesinfos`;
    return this.http.get<Fejlesztes[]>(url);
  }

  buyFejlesztes(type: string) {
    const parameter: Fejlesztes = {
      tipus: type
    };
    console.log(parameter);
    return this.http.post(`${this.fejlesztesUrl}/buyfejlesztes`, parameter);
  }
}
