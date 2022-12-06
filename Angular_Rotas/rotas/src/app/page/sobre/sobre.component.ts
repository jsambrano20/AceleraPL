import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-sobre',
  templateUrl: './sobre.component.html',
  styleUrls: ['./sobre.component.scss'],
})
export class SobreComponent implements OnInit {
  constructor(private activateRoute: ActivatedRoute, private router: Router) {}

  ngOnInit(): void {
    this.activateRoute.params.subscribe((params) =>
      console.log(params['id'], params['username'])
    );
  }

  redirect() {
    this.router.navigate(['contato']);
  }
}
