import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

//Compartilhados
import { NavComponent } from './_shared/_layout/nav/nav.component';
import { FooterComponent } from './_shared/_layout/footer/footer.component';

//Paginas do sistema
import { AlunosComponent } from './alunos/alunos.component';
import { AulasComponent } from './aulas/aulas.component';
import { ProfessorComponent } from './professor/professor.component';
import { CadastroalunosComponent } from './cadastroalunos/cadastroalunos.component';
import { CadastroprofessorComponent } from './cadastroprofessor/cadastroprofessor.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ErrorComponent } from './error/error.component';

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
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    CollapseModule.forRoot(),
    FormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
