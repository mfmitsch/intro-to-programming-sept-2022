import { createActionGroup, props } from '@ngrx/store';

export const SongSorterEvents = createActionGroup({
  source: 'Song List Sorter Events',
  events: {
    sort: props<{ payload: SongListSortOptions }>(),
  },
});

export type SongListSortOptions = 'title' | 'artist' | 'album';
