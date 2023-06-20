import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit, OnChanges } from '@angular/core';

@Component({
  selector: 'app-listar-prato',
  templateUrl: './listar-prato.component.html',
  styleUrls: ['./listar-prato.component.css'],
})
export class ListarPratoComponent implements OnInit {
  public urlAPI: string = 'https://localhost:7198/api/prato';

  public pratos: any;
  public urlImg: string = 'null';
  public valorDigitado: string = ' ';

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getPratos();
  }
  private prato: boolean = false;
  public pratoFiltrado: any;

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

  public getPratos(): void {
    this.http.get(this.urlAPI).subscribe(
      (response) => {
        this.pratos = response;
        this.pratoFiltrado = this.pratos;
      },
      (error) => console.log(error)
    );
  }
}
