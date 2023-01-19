import { EditarMateriaComponent } from './editar-materia/editar-materia.component';
import { EditarProfessorComponent } from './ComponentsProfessores/editar-professor/editar-professor.component';
import { EditarAlunosComponent } from './ComponentsAlunos/editar-alunos/editar-alunos.component';
import { ProfessorComponent } from './ComponentsProfessores/professor/professor.component';
import { CadastroMateriaComponent } from './cadastro-materia/cadastro-materia.component';
import { AulasComponent } from './aulas/aulas.component';
import { ErrorComponent } from './error/error.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { CadastroprofessorComponent } from './ComponentsProfessores/cadastroprofessor/cadastroprofessor.component';
import { CadastroalunosComponent } from './ComponentsAlunos/cadastroalunos/cadastroalunos.component';
import { AlunosComponent } from './ComponentsAlunos/alunos/alunos.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', component: DashboardComponent, pathMatch: 'full' },
  { path: 'Aluno/Lista', component: AlunosComponent },
  { path: 'Aluno/Cadastro', component: CadastroalunosComponent },
  { path: 'Aluno/Editar/:id', component: EditarAlunosComponent },
  { path: 'Aulas/Lista', component: CadastroMateriaComponent },
  { path: 'Aulas/Editar/:id', component: EditarMateriaComponent },
  { path: 'Professor/Lista', component: ProfessorComponent },
  { path: 'Professor/Cadastro', component: CadastroprofessorComponent },
  { path: 'Professor/Editar/:id', component: EditarProfessorComponent },
  { path: '404', component: ErrorComponent },
  { path: '**', redirectTo: '404' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
