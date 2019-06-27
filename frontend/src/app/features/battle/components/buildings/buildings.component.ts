import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { EpuletService } from '../../services/epulet.service';

@Component({
  selector: 'app-buildings',
  templateUrl: './buildings.component.html',
  styleUrls: ['./buildings.component.scss']
})
export class BuildingsComponent implements OnInit {
  @Output() stateChanged = new EventEmitter();

  public activeCard;
  public epuletInfo;
  public zatonyvarInfo;
  public aramlasiranyitoInfo;

  constructor(private epuletService: EpuletService) {}

  ngOnInit() {
    this.getEpuletInfo();
  }

  setActive(id: string) {
    this.activeCard = id;
  }

  getEpuletInfo() {
    this.epuletService.getEpuletInfo().subscribe(
      data => {
        this.epuletInfo = data;
        console.log(this.epuletInfo);
        data.forEach(element => {
          if (element.tipus === 'AramlasIranyito') {
            this.aramlasiranyitoInfo = element;
          }
          if (element.tipus === 'ZatonyVar') {
            this.zatonyvarInfo = element;
          }
        });
      },
      err => console.error(err),
      () => {
        console.log('done loading epuletInfo');
      }
    );
  }

  buyBuilding() {
    let type;
    if (this.activeCard === 'card1') {
      type = 'ZatonyVar';
    }
    if (this.activeCard === 'card2') {
      type = 'AramlasIranyito';
    }

    this.epuletService.buyEpulet(type).subscribe(
      data => {
        console.log(data);
      },
      error => {
        console.log(error);
      },
      () => {
        this.stateChanged.emit(null);
        console.log('done building');
      }
    );
  }
}
