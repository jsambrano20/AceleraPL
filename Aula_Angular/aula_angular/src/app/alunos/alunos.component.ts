import { Component, Input, OnInit, OnChanges } from '@angular/core';

@Component({
  selector: 'app-alunos',
  templateUrl: './alunos.component.html',
  styleUrls: ['./alunos.component.scss'],
})
export class AlunosComponent implements OnInit, OnChanges {
  public testes = 'Novos Alunos';

  @Input() public dados = 'testes';

  public alunos: any = [
    {
      nome: 'Joao',
      email: 'joao@example.com',
    },
    {
      nome: 'Teste1',
      email: 'Teste1@example.com',
    },
    {
      nome: 'Teste2',
      email: 'Teste2@example.com',
    },
  ];
  constructor() {}

  ngOnInit(): void {}

  ngOnChanges() {
    console.log('Houve uma alteração');
  }
}
