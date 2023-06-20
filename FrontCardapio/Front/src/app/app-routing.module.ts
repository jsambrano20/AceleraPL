import { DashboardComponent } from './dashboard/dashboard.component';
import { ListarPratoComponent } from './Prato/listar-prato/listar-prato.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', component: DashboardComponent, pathMatch: 'full' },
  {
    path: '/Front/src/app/Prato/listar-prato',
    component: ListarPratoComponent,
  },
  // { path: '404', component: ErrorComponent },
  // { path: '**', redirectTo: '404' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
