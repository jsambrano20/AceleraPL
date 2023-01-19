import { BsModalService } from 'ngx-bootstrap/modal';
import { Component, Input, OnInit } from '@angular/core';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-modalconfirm',
  templateUrl: './modalconfirm.component.html',
  styleUrls: ['./modalconfirm.component.scss'],
})
export class ModalconfirmComponent implements OnInit {
  @Input() title: string | undefined;
  @Input() message: string | undefined;
  @Input() btnConfirm: string = 'Sim';
  @Input() btnDecline: string = 'Não';

  constructor(private modalService: BsModalService) {}
  confirmResult: Subject<boolean> | undefined;

  ngOnInit(): void {
    this.confirmResult = new Subject();
  }

  onDecline() {
    this.confirmAndClose(false);
  }

  onConfirm() {
    this.confirmAndClose(true);
  }

  private confirmAndClose(value: boolean) {
    this.confirmResult?.next(value);
    this.modalService?.hide();
  }
}
