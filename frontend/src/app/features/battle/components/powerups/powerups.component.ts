import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FejlesztesService } from '../../services/fejlesztes.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-powerups',
  templateUrl: './powerups.component.html',
  styleUrls: ['./powerups.component.scss']
})
export class PowerupsComponent implements OnInit {
  public activeCard;
  public fejlesztesInfo;
  public traktorInfo;
  public kombajnInfo;
  public alkimiaInfo;
  public korallInfo;
  public szonarAgyuInfo;
  public vizalattiHarcmuveszetInfo;
  public isDisabled;
  @Output() stateChanged = new EventEmitter();

  constructor(
    private fejlesztesService: FejlesztesService,
    private toastr: ToastrService
  ) {}

  ngOnInit() {
    this.getFejlesztesInfos();
  }

  setActive(id: string) {
    this.activeCard = id;
  }

  getFejlesztesInfos() {
    this.fejlesztesService.getFejlesztesInfo().subscribe(
      data => {
        this.fejlesztesInfo = data;
        data.forEach(element => {
          if (element.tipus === 'IszapTraktor') {
            this.traktorInfo = element;
          }
          if (element.tipus === 'IszapKombajn') {
            this.kombajnInfo = element;
          }
          if (element.tipus === 'Alkimia') {
            this.alkimiaInfo = element;
          }
          if (element.tipus === 'KorallFal') {
            this.korallInfo = element;
          }
          if (element.tipus === 'SzonarAgyu') {
            this.szonarAgyuInfo = element;
          }
          if (element.tipus === 'VizalattiHarcmuveszet') {
            this.vizalattiHarcmuveszetInfo = element;
          }
        });
      },
      err => console.error(err),
      () => {
        console.log('done loading fejlesztesInfo');
      }
    );
  }

  buyFejlesztes() {
    let type;
    switch (this.activeCard) {
      case 'traktor':
        type = 'IszapTraktor';
        break;
      case 'kombajn':
        type = 'IszapKombajn';
        break;
      case 'korallfal':
        type = 'KorallFal';
        break;
      case 'szonaragyu':
        type = 'SzonarAgyu';
        break;
      case 'vizalatti':
        type = 'VizalattiHarcmuveszet';
        break;
      case 'alkimia':
        type = 'Alkimia';
        break;
    }
    this.fejlesztesService.buyFejlesztes(type).subscribe(
      data => {
        console.log(data);
      },
      error => {
        this.toastr.error(error, 'Nem sikerült fejleszteni :(');
        console.log(error);
      },
      () => {
        this.toastr.success('15 kör múlva elkészül', 'Fejlesztés folyamatban!');
        this.getFejlesztesInfos();
      }
    );
  }
}
