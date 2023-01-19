import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit, OnChanges } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-cadastroalunos',
  templateUrl: './cadastroalunos.component.html',
  styleUrls: ['./cadastroalunos.component.scss'],
})
export class CadastroalunosComponent implements OnInit {
  public mensagem: string = '';
  constructor(private http: HttpClient) {}
  aluno: any;

  public urlAPI: string = 'https://localhost:44357/api/alunos';
  public urlUpload: string = 'https://localhost:44357/api/Upload';
  ngOnInit(): void {
    this.aluno = {};
  }

  submitForm(aluno: any) {
    this.http.post(this.urlAPI, aluno.value).subscribe(
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

  public nomearquivo: any;

  onSelectFile(event: any) {
    this.nomearquivo = <FileList>event.srcElement.files;
  }

  onUpload() {
    // const formData = new FormData();
    // formData.append('file', fileToUpload);
    // this.http.post(this.urlUpload, this.formData).subscribe(
    //   (data) => {
    //     console.log(data);
    //   },
    //   (error) => {
    //     console.log(error);
    //   }
    // );
  }
  //TODO CAMPO FOTO(pegar nome => salvar na pasta)
}
