import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-cadastroprofessor',
  templateUrl: './cadastroprofessor.component.html',
  styleUrls: ['./cadastroprofessor.component.scss'],
})
export class CadastroprofessorComponent implements OnInit {
  constructor() {}

  ngOnInit(): void {}

  submitForm(form: NgForm) {
    console.log(form.value);
  }
}
