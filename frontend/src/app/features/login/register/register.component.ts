import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;

  constructor(
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
    this.registerForm = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [
        Validators.required,
        Validators.minLength(6),
        Validators.pattern('^(?=.*d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{6,}$')
      ]),
      confirmPassword: new FormControl('', [
        Validators.required,
        Validators.minLength(6)
      ]),
      countryName: new FormControl('', [
        Validators.required,
        Validators.maxLength(12)
      ])
    });
  }

  get f() {
    return this.registerForm.controls;
  }

  onSubmit() {
    if (this.registerForm.invalid) {
      if (this.registerForm.get('email').hasError('required')) {
        this.toastr.error('Hiányzó email!');
      }
      if (this.registerForm.get('email').hasError('email')) {
        this.toastr.error('Hibás email formátum!');
      }
      if (this.registerForm.get('password').hasError('required')) {
        this.toastr.error('Hiányzó jelszó!');
      }
      if (this.registerForm.get('password').hasError('minlength')) {
        this.toastr.error('Rövid jelszó!');
      }
      if (this.registerForm.get('password').hasError('pattern')) {
        this.toastr.error('A jelszóban szerepeljen kis és nagybetű és szám! ');
      }
      if (this.registerForm.get('confirmPassword').hasError('required')) {
        this.toastr.error('Hiányzó jelszó ismétlés!');
      }
      if (this.registerForm.get('confirmPassword').hasError('minlength')) {
        this.toastr.error('Rövid jelszó ismétlés!');
      }
      if (this.registerForm.get('countryName').hasError('required')) {
        this.toastr.error('Hiányzó országnév!');
      }
      if (this.registerForm.get('countryName').hasError('maxlength')) {
        this.toastr.error('Túl hosszú országnév! (max 12 karakter)');
      }
      return;
    }

    if (
      this.registerForm.get('confirmPassword').value !==
      this.registerForm.get('password').value
    ) {
      this.toastr.error('A két jelszó nem egyezik meg!');
      return;
    }

    this.authenticationService.register(this.registerForm.value).subscribe(
      data => {
        this.router.navigate(['/login']);
        this.toastr.success('Jelentkezz be!', 'Sikeres regisztráció! :)');
      },
      error => {
        this.toastr.error(error, 'Sikertelen regisztráció :(');
      }
    );
  }
}
