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
        console.log(this.fejlesztesInfo);
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
        this.isDisabled =
          (this.alkimiaInfo && !this.alkimiaInfo.kifejlesztve) ||
          (this.vizalattiHarcmuveszetInfo &&
            !this.vizalattiHarcmuveszetInfo.kifejlesztve) ||
          (this.szonarAgyuInfo && !this.szonarAgyuInfo.kifejlesztve) ||
          (this.korallInfo && !this.korallInfo.kifejlesztve) ||
          (this.kombajnInfo && !this.kombajnInfo.kifejlesztve) ||
          (this.traktorInfo && !this.traktorInfo.kifejlesztve);
        console.log('done loading fejlesztesInfo');
      }
    );
  }

  buyFejlesztes() {
    let type;
    switch (this.activeCard) {
      case 'card1':
        type = 'IszapTraktor';
        break;
      case 'card2':
        type = 'IszapKombajn';
        break;
      case 'card3':
        type = 'KorallFal';
        break;
      case 'card4':
        type = 'SzonarAgyu';
        break;
      case 'card5':
        type = 'VizalattiHarcmuveszet';
        break;
      case 'card6':
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
