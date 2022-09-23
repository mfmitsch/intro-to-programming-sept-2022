import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PlaylistsComponent } from './playlists.component';
import { RouterModule, Routes } from '@angular/router';
import { SongListComponent } from './components/song-list/song-list.component';
import { NavigationComponent } from './components/navigation/navigation.component';
import { OverviewComponent } from './components/overview/overview.component';
import { HttpClientModule } from '@angular/common/http';
import { CreateComponent } from './components/create/create.component';
import { ReactiveFormsModule } from '@angular/forms';
import { StoreModule } from '@ngrx/store';
import { FEATURE_NAME, reducers } from './state';
import { SongEffects } from './state/effects/song.effects';
import { EffectsModule } from '@ngrx/effects';
import { ListSorterComponent } from './components/list-sorter/list-sorter.component';
import { SongSorterEffects } from './state/effects/song-sorter.effects';
import { SongsSummaryComponent } from './components/songs-summary/songs-summary.component';
const routes: Routes = [
  {
    path: '',
    component: PlaylistsComponent,
    children: [
      {
        path: 'overview',
        component: OverviewComponent,
      },

      {
        path: 'songs',
        component: SongListComponent,
      },
      {
        path: 'summaries',
        component:SongsSummaryComponent,
      },
      {
        path: '**',
        redirectTo: 'overview',
      },
    ],
  },
];
@NgModule({
  declarations: [
    PlaylistsComponent,
    SongListComponent,
    NavigationComponent,
    OverviewComponent,
    CreateComponent,
    ListSorterComponent,
    SongsSummaryComponent,
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    HttpClientModule,
    ReactiveFormsModule,
    StoreModule.forFeature(FEATURE_NAME, reducers),
    EffectsModule.forFeature([SongEffects, SongSorterEffects]),
  ],
  exports: [RouterModule],
})
export class PlaylistsModule {}
