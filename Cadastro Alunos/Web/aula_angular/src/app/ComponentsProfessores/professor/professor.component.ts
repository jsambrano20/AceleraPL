import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit, OnChanges } from '@angular/core';

@Component({
  selector: 'app-professor',
  templateUrl: './professor.component.html',
  styleUrls: ['./professor.component.scss'],
})
export class ProfessorComponent implements OnInit {
  public urlAPI: string = 'https://localhost:44357/api/professores';

  public professores: any;
  public urlImg: string = 'null';
  public valorDigitado: string = ' ';

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getProfessores();
  }

  private _filtroLista: string = '';
  private professor: boolean = false;
  public professoresFiltrado: any;

  public get filtroLista() {
    return this._filtroLista;
  }
  public set filtroLista(value: string) {
    this._filtroLista = value;
    this.professoresFiltrado = this.filtroLista
      ? this.filtrarAlunos(this._filtroLista)
      : this.professores;
  }

  filtrarAlunos(filtro: string): any {
    // filtro = filtro.toLocaleLowerCase();

    return this.professores.filter(
      (professor: any) =>
        professor.nome.toLocaleLowerCase().indexOf(filtro) != -1
    );
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

  public getProfessores(): void {
    this.http.get(this.urlAPI).subscribe(
      (response) => {
        this.professores = response;
        this.professoresFiltrado = this.professores;
      },
      (error) => console.log(error)
    );
  }

  removerProfessor(id: number) {
    this.http.delete(this.urlAPI + '/deleteprofessor/' + id).subscribe(
      (data) => {
        console.log(data);
        window.location.reload();
      },
      (error) => {
        console.log(error);
      }
    );
  }
  edicao(id: number) {
    this.http.delete(this.urlAPI + '/deleteprofessor/' + id).subscribe(
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
