import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { Router } from '@angular/router';
import { OrszagService } from '../../services/orszag.service';

@Component({
  selector: 'app-battle',
  templateUrl: './battle.component.html',
  styleUrls: ['./battle.component.scss']
})
export class BattleComponent implements OnInit {
  public orszagInfo;
  public gyongy;
  public korall;
  public capa;
  public foka;
  public csiko;
  public aramlasiranyito;
  public zatonyvar;

  constructor(
    private authenticationService: AuthenticationService,
    private router: Router,
    private orszagService: OrszagService
  ) {}

  getOrszagInfo(): void {
    this.orszagService.getOrszagInfo().subscribe(
      data => {
        this.orszagInfo = data;
        this.gyongy = data.gyongy;
        this.korall = data.korall;
        this.csiko = data.seregInfo.filter(x => x.tipus == 'CsataCsiko');
        this.foka = data.seregInfo.filter(x => x.tipus == 'RohamFoka');
        this.capa = data.seregInfo.filter(x => x.tipus == 'LezerCapa');
        console.log(this.orszagInfo);
        this.aramlasiranyito = data.epuletInfo.filter(
          x => x.tipus == 'AramlasIranyito'
        );
        this.zatonyvar = data.epuletInfo.filter(x => x.tipus == 'ZatonyVar');
      },
      err => console.error(err),
      () => {
        console.log('done loading orszagInfo');
      }
    );
  }

  ngOnInit() {
    this.getOrszagInfo();
  }

  logout() {
    this.authenticationService.logout();
    this.router.navigate(['/login']);
  }

  onActivate(elementRef) {
    elementRef.stateChanged.subscribe(event => {
      console.log('siker');
      this.getOrszagInfo();
    });
  }
}
