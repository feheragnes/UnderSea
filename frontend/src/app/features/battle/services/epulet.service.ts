import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: "root"
})
export class EpuletService {
  private epuletUrl = environment.apiUrl + "/epulet";

  constructor(private http: HttpClient) {}

  // getOrszagInfo(): Observable<any> {
  //   const url = `${this.epuletUrl}/getorszaginfos`;
  //   return this.http.get<any>(url);
  // }

  buyEpulet(type: string) {
    const parameter = {
      tipus: type,
      ar: 1,
      mennyiseg: 1
    };
    console.log(parameter);
    this.http.post<any>(`http://localhost:51554/epulet/buyepulets`, [
      parameter
    ]);
  }
}
