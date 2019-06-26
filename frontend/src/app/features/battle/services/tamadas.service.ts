import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TamadasService {
  private fejlesztesUrl = environment.apiUrl + '/tamadas';

  constructor(private http: HttpClient) {}

  getTamadasInfo(): Observable<any> {
    const url = `${this.fejlesztesUrl}/gettamadasinfos`;
    return this.http.get<any>(url);
  }
}
