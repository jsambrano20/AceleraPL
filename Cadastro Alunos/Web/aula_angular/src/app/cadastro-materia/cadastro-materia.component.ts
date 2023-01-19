import { ModalconfirmComponent } from './../_shared/_utils/modalconfirm/modalconfirm.component';
import { NgForm } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit, OnChanges, ViewChild } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { empty, EMPTY, switchMap, take } from 'rxjs';

@Component({
  selector: 'app-cadastro-materia',
  templateUrl: './cadastro-materia.component.html',
  styleUrls: ['./cadastro-materia.component.scss'],
})
export class CadastroMateriaComponent implements OnInit {
  public urlAPI: string = 'https://localhost:44357/api/materias';
  public materias: any = [];
  public materiasFiltradas: any = [];

  constructor(private http: HttpClient, private modalService: BsModalService) {}
  public valorDigitado: string = '';

  public margemImg: number = 2;
  public larguraImg: number = 50;
  public mostrarImg: boolean = true;

  private _filtroLista: string = '';

  public get filtroLista() {
    return this._filtroLista;
  }

  public set filtroLista(value: string) {
    this._filtroLista = value;

    this.materiasFiltradas = this.filtroLista
      ? this.filtrarMaterias(this._filtroLista)
      : this.materias;
  }

  filtrarMaterias(filtro: string): any {
    filtro = filtro.toLocaleLowerCase();
    return this.materias.filter(
      (materia: any) => materia.nome.toLocaleLowerCase().indexOf(filtro) != -1
    );
  }

  ngOnInit(): void {
    this.getMaterias();
  }

  private idSelected: number = 0;

  getMostarOcultarImg() {
    this.mostrarImg = !this.mostrarImg;
  }

  getKey(evento: KeyboardEvent) {
    this.valorDigitado = (<HTMLInputElement>evento.target).value;
  }

  public getMaterias(): void {
    this.http.get(this.urlAPI).subscribe(
      (response) => {
        this.materias = response;
        this.materiasFiltradas = this.materias;
      }, //API projeto 'Aula7_CadastroAlunos' vscode - http://localhost:5167/aluno
      (error) => console.log(error)
    );
  }

  submitForm(materias: any) {
    this.http.post(this.urlAPI, materias.value).subscribe(
      (data) => {
        console.log(data);
        materias.reset();
        this.materiasFiltradas.push(data);
        // window.location.reload();
      },
      (error) => {
        console.log(error);
      }
    );
  }

  removerAula(id: number) {
    this.idSelected = id;
    // this.confirmaExclusaoRef = this.modalService.show(this.confirmaExclusao, {
    //   class: 'modal-sm',
    // });
    const result$ = this.showConfirm(
      'Confirmação',
      'Realmente deseja excluir?'
    );

    result$
      ?.asObservable()
      .pipe(
        take(1),
        switchMap(async (result) => (result ? this.onConfirm() : EMPTY))
      )
      .subscribe(
        (response) => {
          console.log('Sim');
        },
        (error) => {
          console.log('Não');
        }
      );
  }

  confirmaExclusaoRef: BsModalRef | undefined;
  @ViewChild('confirmaExclusao') confirmaExclusao: any;

  showConfirm(
    title: string,
    message: string,
    btnConfirm?: string,
    btnDecline?: string
  ) {
    const bsModalRef: BsModalRef = this.modalService.show(
      ModalconfirmComponent
    );
    bsModalRef.content.title = title;
    bsModalRef.content.message = message;

    if (btnConfirm) {
      bsModalRef.content.btnConfirm = btnConfirm;
    }

    if (btnDecline) {
      bsModalRef.content.btnDecline = btnDecline;
    }

    return (<ModalconfirmComponent>bsModalRef.content).confirmResult;
  }

  onConfirm() {
    this.http
      .delete(this.urlAPI + '/deletemateria/' + this.idSelected)
      .subscribe(
        (data) => {
          console.log(data);
          window.location.reload();
        },
        (error) => {
          console.log(error);
        }
      );
  }

  onDecline() {
    this.confirmaExclusaoRef?.hide();
  }
}
