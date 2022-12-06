import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastroprofessorComponent } from './cadastroprofessor.component';

describe('CadastroprofessorComponent', () => {
  let component: CadastroprofessorComponent;
  let fixture: ComponentFixture<CadastroprofessorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CadastroprofessorComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CadastroprofessorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
