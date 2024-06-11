import { Component } from '@angular/core';
import { ModalService } from './utils/modals/modal.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent {

  
  title = 'Numerario-Acelera-DotNet';

  constructor(public modalService: ModalService) {}

  openModal() {
    this.modalService.openModal();
  }

  closeModal() {
    this.modalService.closeModal();
  }
  
}
