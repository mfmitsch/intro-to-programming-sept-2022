import { createReducer, on } from '@ngrx/store';
import { SongListSortOptions } from '../song-sorter.actions';
import { SongSorterEvents } from '../song-sorter.actions';
export interface SongSorterState {
  sortBy: SongListSortOptions;
}

const initialState: SongSorterState = {
  sortBy: 'title',
};

export const reducer = createReducer(
  initialState,
  on(SongSorterEvents.sort, (s, a) => ({ sortBy: a.payload }))
);
