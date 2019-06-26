import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EgysegService {
  private egysegUrl = environment.apiUrl + '/egyseg';

  constructor(private http: HttpClient) {}

  getEgysegInfo(): Observable<any> {
    const url = `${this.egysegUrl}/getegyseginfos`;
    return this.http.get<any>(url);
  }

  buyEgyseg() {}
}
