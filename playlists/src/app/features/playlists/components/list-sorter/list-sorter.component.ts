import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { selectSortingBy } from '../../state';
import {
  SongListSortOptions,
  SongSorterEvents,
} from '../../state/song-sorter.actions';

@Component({
  selector: 'app-list-sorter',
  templateUrl: './list-sorter.component.html',
  styleUrls: ['./list-sorter.component.css'],
})
export class ListSorterComponent {
  sortingBy$ = this.store.select(selectSortingBy);
  constructor(private store: Store) {}

  setSortBy(payload: SongListSortOptions) {
    this.store.dispatch(SongSorterEvents.sort({ payload }));
  }
}
