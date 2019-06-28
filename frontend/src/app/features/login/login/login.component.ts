import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  loading = false;
  submitted = false;
  returnUrl: string;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private authenticationService: AuthenticationService,
    private toastr: ToastrService
  ) {
    // redirect to home if already logged in
    if (this.authenticationService.currentUserValue) {
      this.router.navigate(['/']);
    }
  }

  ngOnInit() {
    this.loginForm = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [
        Validators.required,
        Validators.minLength(6)
      ])
    });

    this.returnUrl = this.route.snapshot.queryParams[this.returnUrl] || '/';
  }

  get f() {
    return this.loginForm.controls;
  }

  onSubmit() {
    if (this.loginForm.invalid) {
      if (this.loginForm.get('email').hasError('required')) {
        this.toastr.error('Hiányzó email!');
      }
      if (this.loginForm.get('email').hasError('email')) {
        this.toastr.error('Hibás email!');
      }
      if (this.loginForm.get('password').hasError('required')) {
        this.toastr.error('Hiányzó jelszó!');
      }
      if (this.loginForm.get('password').hasError('minlength')) {
        this.toastr.error('Rövid jelszó!');
      }
      return;
    }

    this.loading = true;
    this.authenticationService.login(this.loginForm.value).subscribe(
      data => {
        this.router.navigate([this.returnUrl]);
        this.toastr.success('Sikeres bejelentkezés! :)');
      },
      error => {
        console.log(error);
        this.toastr.error(error, 'Sikertelen bejelentkezés :(');
        this.loading = false;
      }
    );
  }
}
