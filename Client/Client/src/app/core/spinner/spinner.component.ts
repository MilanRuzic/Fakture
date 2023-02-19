import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { SpinnerService, SpinnerState } from './spinner.service';

@Component({
  selector: 'app-spinner',
  templateUrl: './spinner.component.html',
  styleUrls: ['./spinner.component.css']
})
export class SpinnerComponent implements OnInit, OnDestroy {
  private spinnerStateChanged: Subscription;
  public visible = false;

  constructor(private _spinnerService: SpinnerService) { }

  ngOnInit() {
    this.spinnerStateChanged = this._spinnerService.spinnerState.subscribe((state: SpinnerState) =>
      this.visible = state.show);
  }

  ngOnDestroy() {
    this.spinnerStateChanged.unsubscribe();
  }

}
