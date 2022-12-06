import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-aulas',
  templateUrl: './aulas.component.html',
  styleUrls: ['./aulas.component.scss'],
})
export class AulasComponent implements OnInit {
  public aulas: any = [
    {
      Materia: 'JS',
      data: '10/11/2022 á 20/12/2022',
    },
    {
      Materia: 'React',
      data: '10/11/2022 á 12/12/2022',
    },
    {
      Materia: 'C#',
      data: '10/11/2022 á 28/12/2022',
    },
  ];
  constructor() {}

  ngOnInit(): void {}
}
