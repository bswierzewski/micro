import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { HomeRoutingModule } from './home-routing.module';
import { CoreModule } from 'src/app/core/core.module';

@NgModule({
  declarations: [HomeComponent, DashboardComponent],
  imports: [CommonModule, SharedModule, HomeRoutingModule, CoreModule],
})
export class HomeModule {}
