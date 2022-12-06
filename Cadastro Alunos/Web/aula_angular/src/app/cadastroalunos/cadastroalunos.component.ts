import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-cadastroalunos',
  templateUrl: './cadastroalunos.component.html',
  styleUrls: ['./cadastroalunos.component.scss'],
})
export class CadastroalunosComponent implements OnInit {
  public listas: Array<{ id: number; nomeitem: string }> = [
    { id: 1, nomeitem: 'Item 1' },
    { id: 2, nomeitem: 'Item 2' },
    { id: 3, nomeitem: 'Item 3' },
  ];

  constructor() {}

  ngOnInit(): void {}

  submitForm(form: NgForm) {
    console.log(form.value);
  }
}
