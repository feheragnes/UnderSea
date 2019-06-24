import { Component, OnInit } from "@angular/core";
import { GlobalService } from "../../services/global.service";

@Component({
  selector: "app-rankings",
  templateUrl: "./rankings.component.html",
  styleUrls: ["./rankings.component.scss"]
})
export class RankingsComponent implements OnInit {
  private ranglista;
  constructor(private globalService: GlobalService) {}

  ngOnInit() {
    this.getRanglista();
  }
  getRanglista(): void {
    this.globalService.getRanglista().subscribe(
      data => {
        this.ranglista = data;
      },
      err => console.error(err),
      () => {
        console.log("done loading ranglista");
      }
    );
  }
}
