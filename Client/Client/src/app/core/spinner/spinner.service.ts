import { Injectable, SkipSelf, Optional } from '@angular/core';
import { Subject } from 'rxjs';

export interface SpinnerState {
  show: boolean;
}

@Injectable({
  providedIn: 'root'
})
export class SpinnerService {
  private spinnerSubject = new Subject<SpinnerState>();
  private spinnerCounter: number = 0;
  spinnerState = this.spinnerSubject.asObservable();

  constructor(@Optional() @SkipSelf() prior: SpinnerService) {
    if (prior)
      return prior;
  }

  show() {
    this.spinnerCounter++;
    this.spinnerSubject.next(<SpinnerState>{ show: true });
  }

  hide() {
    this.spinnerCounter--;
    if (this.spinnerCounter <= 0) {
      this.spinnerSubject.next(<SpinnerState>{ show: false });
    }
  }

  showRouteLoader() {
    this.spinnerSubject.next(<SpinnerState>{ show: true });
  }

  hideRouteLoader() {
    this.spinnerSubject.next(<SpinnerState>{ show: false });
  }
}
