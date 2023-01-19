import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit, OnChanges } from '@angular/core';

@Component({
  selector: 'app-alunos',
  templateUrl: './alunos.component.html',
  styleUrls: ['./alunos.component.scss'],
})
export class AlunosComponent implements OnInit {
  public alunos: any;
  public urlImg: string = 'null';
  public valorDigitado: string = ' ';
  public mostrarImg: boolean = true;

  public urlAPI: string = 'https://localhost:44357/api/alunos';

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getAlunos();
  }

  private _filtroLista: string = '';
  private aluno: boolean = false;
  public alunosFiltrado: any;

  public get filtroLista() {
    return this._filtroLista;
  }
  public set filtroLista(value: string) {
    this._filtroLista = value;
    this.alunosFiltrado = this.filtroLista
      ? this.filtrarAlunos(this._filtroLista)
      : this.alunos;
  }

  filtrarAlunos(filtro: string): any {
    // filtro = filtro.toLocaleLowerCase();

    return this.alunos.filter(
      (aluno: any) => aluno.nome.toLocaleLowerCase().indexOf(filtro) != -1
    );
  }

  eventoImg() {
    this.mostrarImg = !this.mostrarImg;
  }

  getMsg() {
    alert('testando');
  }

  getKey(evento: KeyboardEvent) {
    console.log((<HTMLInputElement>evento.target).value);
    this.valorDigitado = (<HTMLInputElement>evento.target).value;
  }

  ngOnChanges() {
    console.log('Houve uma alteração');
  }

  getValor(): number {
    return 1;
  }

  public getAlunos(): void {
    this.http.get(this.urlAPI).subscribe(
      (response) => {
        this.alunos = response;
        this.alunosFiltrado = this.alunos;
      },
      (error) => console.log(error)
    );
  }

  removerAluno(id: number) {
    this.http.delete(this.urlAPI + '/alunodelete/' + id).subscribe(
      (data) => {
        console.log(data);
        window.location.reload();
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
