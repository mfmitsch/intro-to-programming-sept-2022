import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { selectErrorMessage, selectHasAnError } from 'src/app/state';
import { AppEvents } from 'src/app/state/app.actions';

@Component({
  selector: 'app-error-display',
  templateUrl: './error-display.component.html',
  styleUrls: ['./error-display.component.css']
})
export class ErrorDisplayComponent {
  hasError$: Observable<boolean> = this.store.select(selectHasAnError);
  message$: Observable<string | undefined> = this.store.select(selectErrorMessage);

  constructor(private store:Store) { }

  dismiss(){
    this.store.dispatch(AppEvents.errordismissed());
  }


}
