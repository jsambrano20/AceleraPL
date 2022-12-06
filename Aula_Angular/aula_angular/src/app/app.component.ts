import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  title = 'aula_angular';

  ngOnInit(): void {
    // setTimeout(() => {
    //   alert('Joaozinho mil grau');
    // }, 4000);
    //alert('Bora bill');
  }
}
