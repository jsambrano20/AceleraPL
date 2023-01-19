import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ModalModule } from 'ngx-bootstrap/modal';

//Compartilhados
import { NavComponent } from './_shared/_layout/nav/nav.component';
import { FooterComponent } from './_shared/_layout/footer/footer.component';

//Paginas do sistema
import { AlunosComponent } from './ComponentsAlunos/alunos/alunos.component';
import { AulasComponent } from './aulas/aulas.component';
import { ProfessorComponent } from './ComponentsProfessores/professor/professor.component';
import { CadastroalunosComponent } from './ComponentsAlunos/cadastroalunos/cadastroalunos.component';
import { CadastroprofessorComponent } from './ComponentsProfessores/cadastroprofessor/cadastroprofessor.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ErrorComponent } from './error/error.component';
import { CadastroMateriaComponent } from './cadastro-materia/cadastro-materia.component';
import { EditarAlunosComponent } from './ComponentsAlunos/editar-alunos/editar-alunos.component';
import { EditarProfessorComponent } from './ComponentsProfessores/editar-professor/editar-professor.component';
import { EditarMateriaComponent } from './editar-materia/editar-materia.component';
import { ModalconfirmComponent } from './_shared/_utils/modalconfirm/modalconfirm.component';

@NgModule({
  declarations: [
    AppComponent,
    AlunosComponent,
    AulasComponent,
    NavComponent,
    FooterComponent,
    ProfessorComponent,
    CadastroalunosComponent,
    CadastroprofessorComponent,
    DashboardComponent,
    ErrorComponent,
    CadastroMateriaComponent,
    EditarAlunosComponent,
    EditarProfessorComponent,
    EditarMateriaComponent,
    ModalconfirmComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    CollapseModule.forRoot(),
    FormsModule,
    ModalModule.forRoot(),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
