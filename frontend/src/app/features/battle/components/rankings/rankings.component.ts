import { Component, OnInit } from '@angular/core';
import { GlobalService } from '../../services/global.service';

@Component({
  selector: 'app-rankings',
  templateUrl: './rankings.component.html',
  styleUrls: ['./rankings.component.scss']
})
export class RankingsComponent implements OnInit {
  private ranglista;
  filteredranglista;
  constructor(private globalService: GlobalService) {}

  ngOnInit() {
    this.getRanglista();
  }
  getRanglista(): void {
    this.globalService.getRanglista().subscribe(
      data => {
        this.ranglista = data;
        this.filteredranglista = data;
      },
      err => console.error(err),
      () => {
        console.log('done loading ranglista');
      }
    );
  }
  search(value: string) {
    this.filteredranglista = this.ranglista.filter(b => {
      if (b.orszag.toUpperCase().includes(value.toUpperCase())) {
        return b;
      }
    });
  }
}
