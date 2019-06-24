import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: "root"
})
export class GlobalService {
  private globalUrl = environment.apiUrl + "/Global";

  constructor(private http: HttpClient) {}

  getRanglista(): Observable<any> {
    const url = `${this.globalUrl}/GetRanglista`;
    return this.http.get<any>(url);
  }
}
