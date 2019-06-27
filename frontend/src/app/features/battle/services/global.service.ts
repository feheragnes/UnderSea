import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class GlobalService {
  private globalUrl = environment.apiUrl + '/global';

  constructor(private http: HttpClient) {}

  getRanglista(): Observable<any> {
    const url = `${this.globalUrl}/getranglista`;
    return this.http.get<any>(url);
  }

  nextTurn(): Observable<any> {
    const url = `${this.globalUrl}/nextturn`;
    return this.http.post<any>(url, '');
  }

  getAktualisKor() {
    const url = `${this.globalUrl}/getaktualiskor`;
    return this.http.get<any>(url);
  }
}
