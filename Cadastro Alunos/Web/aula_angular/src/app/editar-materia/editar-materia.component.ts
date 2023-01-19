import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import { Component, Input, OnInit, OnChanges } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-editar-materia',
  templateUrl: './editar-materia.component.html',
  styleUrls: ['./editar-materia.component.scss'],
})
export class EditarMateriaComponent implements OnInit {
  constructor(private route: ActivatedRoute, private http: HttpClient) {}

  public urlAPI: string = 'https://localhost:44357/api/materias';
  public materiaFiltrado: any = [];
  public materias: any;
  public materia: any = [];
  public id: number = 0;

  ngOnInit(): void {
    this.id = Number(this.route.snapshot.paramMap.get('id'));
    console.log(this.id);
    this.getMaterias(this.id);
  }

  getMaterias(id: number): void {
    this.http.get(this.urlAPI + '/materiaid/' + id).subscribe(
      (response) => {
        console.log(response);
        this.materia = response;
      },
      (error) => console.log(error)
    );
  }

  submitForm(materia: any) {
    this.http
      .put(this.urlAPI + '/UpdateMateria/' + this.id, materia.value)
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
