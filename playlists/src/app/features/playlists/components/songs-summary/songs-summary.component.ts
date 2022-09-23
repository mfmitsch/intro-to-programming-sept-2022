import { Component, OnInit } from '@angular/core';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { SongSummaryModel } from '../../models';
import { selectSongSummariesModel } from '../../state';

@Component({
  selector: 'app-songs-summary',
  templateUrl: './songs-summary.component.html',
  styleUrls: ['./songs-summary.component.css']
})
export class SongsSummaryComponent  {
  model$: Observable<SongSummaryModel> =  this.store.select(selectSongSummariesModel);
  constructor(private store: Store) { }
}
