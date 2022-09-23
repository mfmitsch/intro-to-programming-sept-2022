import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { SongEvents } from './state/songs.actions';

@Component({
  selector: 'app-playlists',
  templateUrl: './playlists.component.html',
  styleUrls: ['./playlists.component.css'],
})
export class PlaylistsComponent {
  constructor(store: Store) {
    store.dispatch(SongEvents.featureentered());
  }
}
