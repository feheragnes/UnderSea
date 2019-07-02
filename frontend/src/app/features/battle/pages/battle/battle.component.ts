import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { Router } from '@angular/router';
import { OrszagService } from '../../services/orszag.service';
import { GlobalService } from '../../services/global.service';
import { EgysegType } from '../../models/egyseg';
import { EpuletType } from '../../models/epulet';
import { Orszag, SeregInfo, EpuletInfo } from '../../models/orszag';

@Component({
  selector: 'app-battle',
  templateUrl: './battle.component.html',
  styleUrls: ['./battle.component.scss']
})
export class BattleComponent implements OnInit {
  public orszagInfo: Orszag;
  public gyongy: number;
  public korall: number;
  public capaInfo: SeregInfo;
  public fokaInfo: SeregInfo;
  public csikoInfo: SeregInfo;
  public aramlasIranyitoInfo: EpuletInfo;
  public zatonyVarInfo: EpuletInfo;
  public szonarAgyu: boolean;
  public turn: number;
  public levels = ['Lv. 1', 'Lv. 2', 'Lv. 3'];

  constructor(
    private authenticationService: AuthenticationService,
    private router: Router,
    private orszagService: OrszagService,
    private globalService: GlobalService
  ) {}

  ngOnInit() {
    this.getOrszagInfo();
    this.getTurn();
  }

  getOrszagInfo(): void {
    this.orszagService.getOrszagInfo().subscribe(
      data => {
        this.orszagInfo = data;
        this.gyongy = data.gyongy;
        this.korall = data.korall;
        this.csikoInfo = data.seregInfo.find(x => x.tipus === EgysegType.csiko);
        this.fokaInfo = data.seregInfo.find(x => x.tipus === EgysegType.foka);
        this.capaInfo = data.seregInfo.find(x => x.tipus === EgysegType.capa);
        this.aramlasIranyitoInfo = data.epuletInfo.find(
          x => x.tipus === EpuletType.aramlasIranyito
        );
        this.zatonyVarInfo = data.epuletInfo.find(
          x => x.tipus === EpuletType.zatonyVar
        );
      },
      err => console.error(err),
      () => {
        console.log('done loading orszagInfo');
      }
    );
  }

  logout() {
    this.authenticationService.logout();
    this.router.navigate(['/login']);
  }

  onActivate(elementRef) {
    elementRef.stateChanged.subscribe(event => {
      this.getOrszagInfo();
    });
  }

  nextTurn() {
    this.globalService.nextTurn().subscribe(
      data => {
        console.log(data);
      },
      error => {
        console.log(error);
      },
      () => {
        this.getOrszagInfo();
        this.getTurn();
      }
    );
  }
  getTurn() {
    this.globalService.getAktualisKor().subscribe(
      data => {
        this.turn = data.kor;
      },
      err => console.error(err),
      () => {
        console.log('done loading turn');
      }
    );
  }
}
