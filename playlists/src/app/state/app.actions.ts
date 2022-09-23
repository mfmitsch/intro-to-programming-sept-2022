import { createActionGroup, emptyProps } from '@ngrx/store';

export const AppEvents = createActionGroup({
  source: 'App Events',
  events: {
    errorDismissed: emptyProps(),
  },
});
