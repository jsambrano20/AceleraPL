import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-contato',
  templateUrl: './contato.component.html',
  styleUrls: ['./contato.component.scss'],
})
export class ContatoComponent implements OnInit {
  public cadastroForm: FormGroup = this.formBuilder.group({
    nome: ['', Validators.required],
    email: ['', Validators.required, Validators.email],
  });

  constructor(private formBuilder: FormBuilder) {}

  ngOnInit(): void {}

  submitForm() {
    if (this.cadastroForm.valid) {
      console.log(this.cadastroForm);
      console.log(this.cadastroForm.value);
      console.log(this.cadastroForm.value.nome);
    } else {
      console.log('Invalido paizao');
    }
  }
}
