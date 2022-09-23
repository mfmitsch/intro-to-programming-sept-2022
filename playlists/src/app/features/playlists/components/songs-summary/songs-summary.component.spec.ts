import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SongsSummaryComponent } from './songs-summary.component';

describe('SongsSummaryComponent', () => {
  let component: SongsSummaryComponent;
  let fixture: ComponentFixture<SongsSummaryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SongsSummaryComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SongsSummaryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
