import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit, OnChanges } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-cadastroprofessor',
  templateUrl: './cadastroprofessor.component.html',
  styleUrls: ['./cadastroprofessor.component.scss'],
})
export class CadastroprofessorComponent implements OnInit {
  public mensagem: string = '';
  constructor(private http: HttpClient) {}
  professor: any;

  public urlAPI: string = 'https://localhost:44357/api/professores';

  ngOnInit(): void {
    this.professor = {};
  }

  submitForm(professor: any) {
    this.http.post(this.urlAPI, professor.value).subscribe(
      (data) => {
        console.log(data);
        this.mensagem = 'salvo com sucesso';
      },
      (error) => {
        console.log(error);
        this.mensagem = 'erro';
      }
    );
  }
}
