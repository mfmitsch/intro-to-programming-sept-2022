export interface SongListModel {
  data: SongListItem[];
}

export interface SongListItem {
  id: string;
  title: string;
  artist: string;
  album?: string;
}

export interface SongCreate {
  title: string;
  artist: string;
  album?: string;
}

export interface SongSummaryModel {
  numberOfSongs: number;
  songsWithAlbums: number;
  songsWithoutAlbums: number;
}
