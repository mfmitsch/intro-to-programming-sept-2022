import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { filter, map, tap } from 'rxjs';
import { SongListSortOptions, SongSorterEvents } from '../song-sorter.actions';
import { SongEvents } from '../songs.actions';
@Injectable()
export class SongSorterEffects {
  loadSortingPrefs$ = createEffect(() => {
    return this.actions$.pipe(
      ofType(SongEvents.featureentered), // when the feature is entered.
      map(() => localStorage.getItem('sortingby')), // check localstorate = > string | null (val)
      filter((val) => val !== null), // if it is null, stop here.
      filter((val) => val === 'title' || val === 'album' || val === 'artist'),
      map((v) => v as SongListSortOptions), // because this is Typescript that value is a SongListSortOption ("title" | "artist" | "album")
      map((payload) => SongSorterEvents.sort({ payload }))
    );
  });
  saveSortingPrefs$ = createEffect(
    () => {
      return this.actions$.pipe(
        ofType(SongSorterEvents.sort),
        tap(({ payload }) => localStorage.setItem('sortingby', payload))
      );
    },
    { dispatch: false }
  );
  constructor(private actions$: Actions) {}
}
