import { ErrorComponent } from './error/error.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { CadastroprofessorComponent } from './cadastroprofessor/cadastroprofessor.component';
import { ProfessorComponent } from './professor/professor.component';
import { CadastroalunosComponent } from './cadastroalunos/cadastroalunos.component';
import { AlunosComponent } from './alunos/alunos.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', component: DashboardComponent, pathMatch: 'full' },
  { path: 'lista-alunos', component: AlunosComponent },
  { path: 'cadastro-alunos', component: CadastroalunosComponent },
  { path: 'lista-professores', component: ProfessorComponent },
  { path: 'cadastro-professores', component: CadastroprofessorComponent },
  { path: '404', component: ErrorComponent },
  { path: '**', redirectTo: '404' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
