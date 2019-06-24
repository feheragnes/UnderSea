import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: "root"
})
export class GlobalService {
  private globalUrl = "http://localhost:51554/Global";

  constructor(private http: HttpClient) {}

  getRanglista(): Observable<any> {
    const url = `${this.globalUrl}/GetRanglista`;
    return this.http.get<any>(url);
  }
}
