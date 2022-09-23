import { createReducer, on } from "@ngrx/store";
import * as fromSongEvents from '../../features/playlists/state/songs.actions'
import { AppEvents } from "../app.actions";
export interface ErrorsState {
  hasErrors: boolean;
  message?: string;
}
const initialstate: ErrorsState = {
  hasErrors:false,
};
export const reducer = createReducer(initialstate,
  on(AppEvents.errordismissed, () => initialstate),
  on(fromSongEvents.SongEvents.error, (s,a) => ({
    hasErrors:true,message:a.payload.message,
  })));
