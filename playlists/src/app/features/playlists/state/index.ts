import {
  ActionReducerMap,
  createFeatureSelector,
  createSelector,
} from '@ngrx/store';
import { SongListModel, SongSummaryModel } from '../models';
import * as fromSongs from './reducers/songs.reducer';
import * as fromSongSorter from './reducers/song-sorter.reducer';
import { SongListSortOptions } from './song-sorter.actions';
import { SongsSummaryComponent } from '../components/songs-summary/songs-summary.component';
export const FEATURE_NAME = 'playlists';

// describe the state of this feature for typescript

export interface PlaylistsState {
  songList: fromSongs.SongState;
  songSort: fromSongSorter.SongSorterState;
}

export const reducers: ActionReducerMap<PlaylistsState> = {
  songList: fromSongs.reducer,
  songSort: fromSongSorter.reducer,
};

// 1. Create a Feature Selector
const selectFeature = createFeatureSelector<PlaylistsState>(FEATURE_NAME);

// 2. A selector per "branch" of the feature state
const selectSongListBranch = createSelector(selectFeature, (f) => f.songList);
const selectSongSortBranch = createSelector(selectFeature, (f) => f.songSort);
// 3. Any "Helpers" (optional)

const { selectAll: selectSongListEntities } =
  fromSongs.adapter.getSelectors(selectSongListBranch);

// 4. The exported selectors that our components need:

// TODO: We need a function that returns the SongListModel

export const selectSortingBy = createSelector(
  selectSongSortBranch,
  (b) => b.sortBy
);
export const selectSongListModel = createSelector(
  selectSongListEntities, // SongListEntity[] -> songs
  selectSortingBy, // "title" => sortingBy
  (songs, sortingBy) => {
    const data = [
      ...songs.sort((lhs, rhs) => {
        const normalizedLhs = lhs[sortingBy]?.toLowerCase() || '';
        const normalizedRhs = rhs[sortingBy]?.toLowerCase() || '';
        if (normalizedLhs < normalizedRhs) {
          return -1;
        }
        if (normalizedLhs > normalizedRhs) {
          return 1;
        }

        return 0;
      }),
    ];
    return {
      data,
    } as SongListModel;
  }
);


export const selectSongSummariesModel = createSelector(
  selectSongListEntities,
  (songs) =>
  ({
    numberOfSongs: songs.length,
    songsWithAlbums:songs.filter((songs) => songs.album).length,
    songsWithoutAlbums:songs.filter((songs) => !songs.album).length,
  })
)
