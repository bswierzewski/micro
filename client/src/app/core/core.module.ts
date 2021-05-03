import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NotFoundComponent } from './http/not-found/not-found.component';
import { ServerErrorComponent } from './http/server-error/server-error.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';

@NgModule({
  declarations: [
    NotFoundComponent,
    ServerErrorComponent,
    HeaderComponent,
    FooterComponent,
  ],
  imports: [CommonModule],
  exports: [HeaderComponent, FooterComponent],
})
export class CoreModule {}
