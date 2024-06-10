import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ModalService {
  private isVisibleSubject = new BehaviorSubject<boolean>(false);
  isVisible$ = this.isVisibleSubject.asObservable();

  openModal() {
    this.isVisibleSubject.next(true);
  }

  closeModal() {
    this.isVisibleSubject.next(false);
  }
}
