import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Orszag } from "../models/orszag";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: "root"
})
export class OrszagService {
  private orszagUrl = environment.apiUrl + "/orszag";

  constructor(private http: HttpClient) {}

  getOrszagInfo(): Observable<Orszag> {
    const url = `${this.orszagUrl}/getorszaginfos`;
    return this.http.get<Orszag>(url);
  }
}
