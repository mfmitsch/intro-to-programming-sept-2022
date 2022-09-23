import { Component } from '@angular/core';
import { SongListItem, SongListModel } from '../../models';
import { Observable } from 'rxjs';
import { Store } from '@ngrx/store';
import { SongEvents } from '../../state/songs.actions';
import { selectSongListModel } from '../../state';

@Component({
  selector: 'app-song-list',
  templateUrl: './song-list.component.html',
  styleUrls: ['./song-list.component.css'],
})
export class SongListComponent {
  model$: Observable<SongListModel> = this.store.select(selectSongListModel);

  constructor(private store: Store) {}

  addToPlayList(item: SongListItem) {
    this.store.dispatch(
      SongEvents.addedtoplaylist({ payload: { id: item.id } })
    );
  }

  addAlbum(item: SongListItem) {
    this.store.dispatch(
      SongEvents.titlechangerequested({
        payload: { id: item.id, newTitle: 'GREATEST HITS' },
      })
    );
  }
}
