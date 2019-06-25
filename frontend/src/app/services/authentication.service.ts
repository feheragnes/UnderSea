import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Router } from "@angular/router";
import { BehaviorSubject, Observable } from "rxjs";
import { User } from "../features/battle/models/user";
import { environment } from "src/environments/environment";
import { map } from "rxjs/operators";

@Injectable({
  providedIn: "root"
})
export class AuthenticationService {
  private currentUserSubject: BehaviorSubject<User>;
  public currentUser: Observable<User>;

  constructor(private http: HttpClient) {
    this.currentUserSubject = new BehaviorSubject<User>(
      JSON.parse(localStorage.getItem("currentUser"))
    );
    this.currentUser = this.currentUserSubject.asObservable();
  }

  public get currentUserValue(): User {
    return this.currentUserSubject.value;
  }

  login(currentUser: User) {
    const email = currentUser.email;
    const password = currentUser.password;
    return this.http
      .post<any>(environment.apiUrl + `/account/login`, { email, password })
      .pipe(
        map(user => {
          // login successful if there's a jwt token in the response
          if (user && user.token) {
            // store user details and jwt token in local storage to keep user logged in between page refreshes
            localStorage.setItem("currentUser", JSON.stringify(user));
            this.currentUserSubject.next(user);
          }

          return user;
        })
      );
  }

  register(user: User) {
    const parameter = {
      email: user.email,
      password: user.password,
      confirmPassword: user.confirmPassword,
      countryName: user.countryName
    };
    console.log(parameter);
    return this.http.post<any>(
      environment.apiUrl + `/account/register`,
      parameter
    );
  }

  buyEpulet(type: string) {
    const parameter = {
      tipus: type,
      ar: 1,
      mennyiseg: 1
    };
    console.log(parameter);
    this.http.post<any>(`${environment.apiUrl}/epulet/buyepulets`, [parameter]);
  }

  logout() {
    // remove user from local storage to log user out
    localStorage.removeItem("currentUser");
    this.currentUserSubject.next(null);
  }
}
