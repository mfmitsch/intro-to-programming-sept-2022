import { setupWorker, rest } from 'msw';

// import { environment } from 'src/environments/environment';
import {
  SongCreate,
  SongListItem,
  SongListModel,
} from '../app/features/playlists/models';
const fakeData: SongListModel = {
  data: [
    { id: '1', title: 'Pump up the Volume', artist: 'M/A/R/S' },
    {
      id: '2',
      title: 'No More Shall We Part',
      artist: 'Nick Cave and the Bad Seeds',
      album: 'No More Shall We Part',
    },
  ],
};

let lastId = 99;
export const mocks = [
  rest.get('http://localhost:1337/songs', (req, res, ctx) => {
    return res(ctx.status(200), ctx.json(fakeData));
  }),

  rest.post('http://localhost:1337/songs', async (req, res, ctx) => {
    const request = await req.json<SongCreate>();
    const response = { ...request, id: (++lastId).toString() + 'FAKE' };

    if (response.artist === 'toad the wet sprocket') {
      return res(ctx.status(400));
    } else {
      return res(ctx.status(201), ctx.json(response));
    }
  }),
];

const worker = setupWorker(...mocks);

worker.start();

export { worker, rest };
