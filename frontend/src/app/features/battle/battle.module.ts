import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { BattleRoutingModule } from './battle-routing.module';
import { BattleService } from './services/battle.service';
import { CompComponent } from './components/comp/comp.component';
import { ExamplePageComponent } from './pages/example/example.page.component';

@NgModule({
    imports: [
        SharedModule,
        BattleRoutingModule
    ],
    providers: [
        BattleService
    ],
    declarations: [
        CompComponent, 
        ExamplePageComponent
    ]
})
export class BattleModule { }
