import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ExamplePageComponent } from './pages/example/example.page.component';

const routes: Routes = [
    { path: '', component: ExamplePageComponent },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class BattleRoutingModule { }
