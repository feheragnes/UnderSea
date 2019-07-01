import { Component, OnInit, Input } from '@angular/core';
import { FejlesztesService } from '../../services/fejlesztes.service';
import { FejlesztesType } from '../../models/fejlesztes';

@Component({
  selector: 'app-country',
  templateUrl: './country.component.html',
  styleUrls: ['./country.component.scss']
})
export class CountryComponent implements OnInit {
  @Input() aramlasIranyito;
  @Input() zatonyVar;
  public szonarAgyu = false;
  public alkimia = false;
  public korall = false;
  public traktor = false;
  public kombajn = false;
  public vizalatti = false;

  constructor(private fejlesztesService: FejlesztesService) {}

  ngOnInit() {
    this.getFejlesztesInfo();
  }

  getFejlesztesInfo() {
    this.fejlesztesService.getFejlesztesInfo().subscribe(
      data => {
        data.forEach(element => {
          if (element.tipus === FejlesztesType.szonarAgyu) {
            this.szonarAgyu = element.kifejlesztve;
          }
          if (element.tipus === FejlesztesType.traktor) {
            this.traktor = element.kifejlesztve;
          }
          if (element.tipus === FejlesztesType.kombajn) {
            this.kombajn = element.kifejlesztve;
          }
          if (element.tipus === FejlesztesType.alkimia) {
            this.alkimia = element.kifejlesztve;
          }
          if (element.tipus === FejlesztesType.korall) {
            this.korall = element.kifejlesztve;
          }
          if (element.tipus === FejlesztesType.vizalatti) {
            this.vizalatti = element.kifejlesztve;
          }
        });
      },
      err => console.error(err),
      () => {
        console.log('done loading fejlesztesInfo');
      }
    );
  }
}
