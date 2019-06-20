import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { LoginComponent } from "./features/login/login/login.component";
import { RegisterComponent } from "./features/login/register/register.component";

const routes: Routes = [
  {
    path: "battle",
    loadChildren: "./features/battle/battle.module#BattleModule"
  },
  { path: "login", component: LoginComponent },
  { path: "register", component: RegisterComponent },
  { path: "", redirectTo: "/battle", pathMatch: "full" }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
