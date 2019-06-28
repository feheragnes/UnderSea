import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { EpuletService } from '../../services/epulet.service';
import { ToastrService } from 'ngx-toastr';

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

  constructor(
    private epuletService: EpuletService,
    private toastr: ToastrService
  ) {}

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
        this.toastr.error(error, 'Nem sikerült építeni :(');
      },
      () => {
        this.stateChanged.emit(null);
        this.toastr.success('5 kör múlva elkészül', 'Már épül is!');
        console.log('done building');
      }
    );
  }
}
