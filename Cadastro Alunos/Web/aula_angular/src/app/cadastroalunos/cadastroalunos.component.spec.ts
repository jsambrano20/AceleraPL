import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastroalunosComponent } from './cadastroalunos.component';

describe('CadastroalunosComponent', () => {
  let component: CadastroalunosComponent;
  let fixture: ComponentFixture<CadastroalunosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CadastroalunosComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CadastroalunosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
