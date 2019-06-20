import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router } from "@angular/router";
import { AuthenticationService } from "src/app/services/authentication.service";
import { AlertService } from "src/app/services/alert.service";
import { first } from "rxjs/operators";

@Component({
  selector: "app-register",
  templateUrl: "./register.component.html",
  styleUrls: ["./register.component.scss"]
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  loading = false;
  submitted = false;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private authenticationService: AuthenticationService,
    private alertService: AlertService
  ) {
    // redirect to home if already logged in
    if (this.authenticationService.currentUserValue) {
      this.router.navigate(["/"]);
    }
  }

  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      email: ["", Validators.required],
      password: ["", Validators.required],
      passwordagain: ["", Validators.required],
      countryname: ["", Validators.required]
    });
  }

  // convenience getter for easy access to form fields
  get f() {
    return this.registerForm.controls;
  }

  onSubmit() {
    console.log(
      this.f.email.value,
      this.f.password.value,
      this.f.passwordagain.value,
      this.f.countryname.value
    );
    this.submitted = true;

    // stop here if form is invalid
    if (this.registerForm.invalid) {
      return;
    }

    this.loading = true;

    this.authenticationService
      .register(
        this.f.email.value,
        this.f.password.value,
        this.f.passwordagain.value,
        this.f.countryname.value
      )
      .pipe(first())
      .subscribe(
        data => {
          this.router.navigate(["/login"]);
        },
        error => {
          this.alertService.error(error);
          this.loading = false;
        }
      );
  }
}
