import { ErrorComponent } from './page/error/error.component';
import { ContatoComponent } from './page/contato/contato.component';
import { SobreComponent } from './page/sobre/sobre.component';
import { HomeComponent } from './page/home/home.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'sobre/:id/:username', component: SobreComponent },
  { path: 'contato', component: ContatoComponent },
  { path: '404', component: ErrorComponent },
  { path: '**', redirectTo: '404' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
