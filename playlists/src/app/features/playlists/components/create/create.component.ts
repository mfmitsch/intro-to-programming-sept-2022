import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import { SongCreate } from '../../models';
import { SongEvents } from '../../state/songs.actions';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css'],
})
export class CreateComponent {
  form = new FormGroup<CreateForm>({
    title: new FormControl<string>('', { nonNullable: true, validators:[
      Validators.required,Validators.minLength(3),Validators.maxLength(50),
    ] }),
    artist: new FormControl<string>('', { nonNullable: true, validators:[
      Validators.required,
    ] }),
    album: new FormControl<string>('', { nonNullable: true }),
  });
  constructor(private store: Store) {}

  get title() { return this.form.controls.title;}
  get artist() {return this.form.controls.artist;}
  get album() {return this.form.controls.artist;}

  addThisSong(theInputThatShouldHaveTheFocus: HTMLInputElement) {
    if(this.form.valid){
      const song: SongCreate = {
        title: this.form.controls.title.value,
        artist: this.form.controls.artist.value,
        album: this.form.controls.album.value || undefined,
      };
      this.store.dispatch(SongEvents.added({ payload: song }));
      this.form.reset();
      theInputThatShouldHaveTheFocus.focus();
    }
    else {
      console.log(this.form.valid);
    }
  }
}

type CreateForm = {
  title: FormControl<string>;
  artist: FormControl<string>;
  album: FormControl<string>;
};
