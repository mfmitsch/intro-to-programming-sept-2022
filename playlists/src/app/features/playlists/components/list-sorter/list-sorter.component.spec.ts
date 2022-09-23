import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListSorterComponent } from './list-sorter.component';

describe('ListSorterComponent', () => {
  let component: ListSorterComponent;
  let fixture: ComponentFixture<ListSorterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListSorterComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListSorterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
