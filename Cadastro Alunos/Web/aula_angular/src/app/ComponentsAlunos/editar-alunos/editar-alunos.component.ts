import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import { Component, Input, OnInit, OnChanges } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-editar-alunos',
  templateUrl: './editar-alunos.component.html',
  styleUrls: ['./editar-alunos.component.scss'],
})
export class EditarAlunosComponent implements OnInit {
  constructor(private route: ActivatedRoute, private http: HttpClient) {}

  public urlAPI: string = 'https://localhost:44357/api/alunos';
  public alunosFiltrado: any = [];
  public alunos: any;
  public aluno: any = [];
  public id: number = 0;

  ngOnInit(): void {
    this.id = Number(this.route.snapshot.paramMap.get('id'));
    console.log(this.id);
    this.getAlunos(this.id);
  }

  getAlunos(id: number): void {
    this.http.get(this.urlAPI + '/alunoid/' + id).subscribe(
      (response) => {
        console.log(response);
        this.aluno = response;
      },
      (error) => console.log(error)
    );
  }

  submitForm(aluno: any) {
    this.http
      .put(this.urlAPI + '/UpdateAluno/' + this.id, aluno.value)
      .subscribe(
        (data) => {
          console.log(data);
        },
        (error) => {
          console.log(error);
        }
      );
  }
}
