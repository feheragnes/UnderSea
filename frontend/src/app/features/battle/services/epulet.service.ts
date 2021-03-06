import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EpuletService {
  private epuletUrl = environment.apiUrl + '/epulet';

  constructor(private http: HttpClient) {}

  getEpuletInfo(): Observable<any> {
    const url = `${this.epuletUrl}/getuserepulets`;
    return this.http.get<any>(url);
  }

  buyEpulet(type: string) {
    const parameter = {
      tipus: type,
      ar: 1,
      mennyiseg: 1
    };
    console.log(parameter);
    return this.http.post<any>(`${this.epuletUrl}/buyepulets`, [parameter]);
  }
}
