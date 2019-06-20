import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { BattleComponent } from "./pages/battle/battle.component";
import { BuildingsComponent } from "./components/buildings/buildings.component";
import { AttackComponent } from "./components/attack/attack.component";

const routes: Routes = [
  {
    path: "",
    component: BattleComponent,
    children: [
      { path: "buildings", component: BuildingsComponent },
      { path: "attack", component: AttackComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BattleRoutingModule {}
