import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import { Component, Input, OnInit, OnChanges } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-editar-professor',
  templateUrl: './editar-professor.component.html',
  styleUrls: ['./editar-professor.component.scss'],
})
export class EditarProfessorComponent implements OnInit {
  constructor(private route: ActivatedRoute, private http: HttpClient) {}

  public urlAPI: string = 'https://localhost:44357/api/professores';
  public professorFiltrado: any = [];
  public professores: any;
  public professor: any = [];
  public id: number = 0;

  ngOnInit(): void {
    this.id = Number(this.route.snapshot.paramMap.get('id'));
    console.log(this.id);
    this.getProfessores(this.id);
  }

  getProfessores(id: number): void {
    this.http.get(this.urlAPI + '/professorid/' + id).subscribe(
      (response) => {
        console.log(response);
        this.professor = response;
      },
      (error) => console.log(error)
    );
  }

  submitForm(professor: any) {
    this.http
      .put(this.urlAPI + '/UpdateProfessor/' + this.id, professor.value)
      .subscribe(
        (data) => {
          console.log(data);
        },
        (error) => {
          console.log(error);
        }
      );
  }
}
