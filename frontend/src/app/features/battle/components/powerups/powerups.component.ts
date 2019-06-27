import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FejlesztesService } from '../../services/fejlesztes.service';

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
  public vizalattiHarmuveszetInfo;
  @Output() stateChanged = new EventEmitter();

  constructor(private fejlesztesService: FejlesztesService) {}

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
          if (element.tipus === 'VizalattiHarmuveszet') {
            this.vizalattiHarmuveszetInfo = element;
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
        type = 'VizalattiHarmuveszet';
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
        console.log(error);
      },
      () => {
        console.log('done building');
        this.getFejlesztesInfos();
      }
    );
  }
}
