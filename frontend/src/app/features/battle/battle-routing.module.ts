import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { BattleComponent } from "./pages/battle/battle.component";
import { BuildingsComponent } from "./components/buildings/buildings.component";
import { AttackComponent } from "./components/attack/attack.component";
import { PowerupsComponent } from "./components/powerups/powerups.component";
import { ArmyComponent } from "./components/army/army.component";
import { RankingsComponent } from "./components/rankings/rankings.component";
import { FightsComponent } from "./components/fights/fights.component";

const routes: Routes = [
  {
    path: "",
    component: BattleComponent,
    children: [
      { path: "buildings", component: BuildingsComponent },
      { path: "attack", component: AttackComponent },
      { path: "powerups", component: PowerupsComponent },
      { path: "army", component: ArmyComponent },
      { path: "rankings", component: RankingsComponent },
      { path: "fight", component: FightsComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BattleRoutingModule {}
