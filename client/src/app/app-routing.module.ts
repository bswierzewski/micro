import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotFoundComponent } from './core/http/not-found/not-found.component';
import { ServerErrorComponent } from './core/http/server-error/server-error.component';

export const routes: Routes = [
  {
    path: 'home',
    loadChildren: () =>
      import('./modules/home/home.module').then((m) => m.HomeModule),
  },
  {
    path: 'admin',
    loadChildren: () =>
      import('./modules/admin/admin.module').then((m) => m.AdminModule),
  },
  // {
  //   path: 'server-error',
  //   component: ServerErrorComponent,
  // },
  // {
  //   path: 'not-found',
  //   component: NotFoundComponent,
  // },
  // { path: '**', redirectTo: 'not-found', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
