import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NotFoundComponent } from './http/not-found/not-found.component';
import { ServerErrorComponent } from './http/server-error/server-error.component';



@NgModule({
  declarations: [
    NotFoundComponent,
    ServerErrorComponent
  ],
  imports: [
    CommonModule
  ]
})
export class CoreModule { }
