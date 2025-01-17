import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SettingsRoutingModule } from './settings-routing.module';
import { SharedModule } from '../shared/shared.module';
import { MokebComponent } from './mokeb/mokeb.component';
import { SettingsComponent } from './settings.component';
import { CreateUpdateMokebComponent } from './create-update-mokeb/create-update-mokeb.component';
import { MokebSettingsComponent } from './mokeb-settings/mokeb-settings.component';

@NgModule({
  declarations: [SettingsComponent, MokebComponent, CreateUpdateMokebComponent],
  imports: [CommonModule, SettingsRoutingModule, SharedModule],
})
export class SettingsModule {}
