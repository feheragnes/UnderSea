import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FejlesztesService {
  private fejlesztesUrl = environment.apiUrl + '/fejlesztes';

  constructor(private http: HttpClient) {}

  getFejlesztesInfo(): Observable<any> {
    const url = `${this.fejlesztesUrl}/getfejlesztesinfos`;
    return this.http.get<any>(url);
  }

  buyFejlesztes(type: string) {
    const parameter = {
      tipus: type
    };
    console.log(parameter);
    return this.http.post<any>(`${this.fejlesztesUrl}/buyfejlesztes`, [
      parameter
    ]);
  }
}
