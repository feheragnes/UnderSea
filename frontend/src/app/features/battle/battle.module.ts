import { NgModule } from '@angular/core';
import { BattleRoutingModule } from './battle-routing.module';
import { BattleComponent } from './pages/battle/battle.component';
import { HttpClientModule } from '@angular/common/http';
import {
  MatButtonModule,
  MatCardModule,
  MatChipsModule,
  MatExpansionModule,
  MatIconModule,
  MatInputModule,
  MatListModule,
  MatProgressSpinnerModule,
  MatSelectModule,
  MatSidenavModule,
  MatSliderModule,
  MatToolbarModule,
  MatGridListModule,
  MatTooltipModule
} from '@angular/material';
import { BuildingsComponent } from './components/buildings/buildings.component';
import { AttackComponent } from './components/attack/attack.component';
import { PowerupsComponent } from './components/powerups/powerups.component';
import { FightsComponent } from './components/fights/fights.component';
import { RankingsComponent } from './components/rankings/rankings.component';
import { ArmyComponent } from './components/army/army.component';
import { CountryComponent } from './components/country/country.component';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@NgModule({
  imports: [
    BattleRoutingModule,
    MatCardModule,
    MatChipsModule,
    MatExpansionModule,
    MatIconModule,
    MatInputModule,
    MatListModule,
    MatProgressSpinnerModule,
    MatSelectModule,
    MatSidenavModule,
    MatSliderModule,
    MatToolbarModule,
    MatGridListModule,
    MatButtonModule,
    HttpClientModule,
    FormsModule,
    MatTooltipModule,
    CommonModule
  ],
  providers: [],
  declarations: [
    BattleComponent,
    BuildingsComponent,
    AttackComponent,
    PowerupsComponent,
    FightsComponent,
    RankingsComponent,
    ArmyComponent,
    CountryComponent
  ]
})
export class BattleModule {}
