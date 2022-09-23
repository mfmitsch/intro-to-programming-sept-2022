import { startWith } from 'rxjs';

describe('basic types in TypeScript', () => {
  it('explicitly typed variables', () => {
    // initializing also implies data type
    let x = 10;

    expect(typeof x).toBe('number');

    // this is implicitly typed to "any"
    let y;

    y = 10;
    expect(typeof y).toBe('number');

    y = 'Tacos';
    expect(typeof y).toBe('string');

    let name: number | string;

    name = 1138;

    name = 'Bob';

    //name = () => {}
  });
  it('string weirdness', () => {
    let name = 'Jeff';
    let age = 53;
    expect(name).toBe('Jeff');

    let info = `This is ${name} and they are ${age} years old.`;

    expect(info).toBe('This is Jeff and they are 53 years old.');
  });
  describe('User Defined Types', () => {
    it('interfaces in typescript', () => {
      interface Movie {
        title: string;
        director: string;
        yearReleased: number;
        cast?: { name: string; role: string }[];
      }

      const starwars: Movie = {
        title: 'Star Wars',
        director: 'Lucas',
        yearReleased: 1978,
        cast: [{ name: 'Mark Hammil', role: 'Luke Skywalker' }],
      };

      //starwars.yearReleased = 1977; // "Mutating the Object"

      const updatedStarWars = { ...starwars, yearReleased: 1977 };

      expect(starwars.yearReleased).toBe(1978);
      expect(updatedStarWars.yearReleased).toBe(1977);
    });
    it('working with arrays', () => {
      const friends = ['Sean', 'Zach', 'Jamie', 'Leeroy'];

      const updatedFriends = ['Tara', ...friends, 'Billy'];
      expect(updatedFriends).toEqual([
        'Tara',
        'Sean',
        'Zach',
        'Jamie',
        'Leeroy',
        'Billy',
      ]);
    });
  });
});

describe('Functions', () => {
  it('named functions', () => {
    expect(formatName('Luke', 'Skywalker')).toBe('Skywalker, Luke');

    expect(formatName('Han', 'Solo', 'D')).toBe('Solo, Han D.');

    function formatName(
      firstName: string,
      lastName: string,
      mi?: string
    ): string {
      let fullName = `${lastName}, ${firstName}`;
      if (mi != undefined) {
        fullName += ` ${mi}.`;
      }
      return fullName;
    }
  });
  it('anonymous functions', () => {
    const formatName = (firstName: string, lastName: string): string =>
      `${lastName}, ${firstName}`;

    expect(formatName('Luke', 'Skywalker')).toBe('Skywalker, Luke');
  });

  describe('Array Methods', () => {
    it('has a foreach', () => {
      let total = 0;
      const numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9];
      numbers.forEach((e, i, c) => {
        console.log({ e, i, c });
        total += e;
      });

      expect(total).toBe(45);
    });

    describe('array methods that return a new array', () => {
      it('has a map', () => {
        // map is like "select" in LINQ
        const numbers = [1, 2, 3, 4];
        // if there is a place you want to go, it will get you there you know, it's the map.

        const doubled = numbers.map((number) => number * 2);
        expect(doubled).toEqual([2, 4, 6, 8]);
      });
      it('filter', () => {
        const numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9];

        const evens = numbers.filter((e) => e % 2 === 0);

        expect(evens).toEqual([2, 4, 6, 8]);
      });
    });

    describe('array methods that return a single (scalar) value', () => {
      it('checking if every element in the array meets a criteria', () => {
        const numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9];

        const allEven = numbers.every((n) => n % 2 === 0);
        expect(allEven).toBeFalse();

        const someEven = numbers.some((n) => n % 2 === 0);
        expect(someEven).toBeTrue();
      });

      it('the dreaded reduce', () => {
        const numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9];

        let total = numbers.reduce((s, n) => s + n);
        expect(total).toBe(45);

        total = numbers.reduce((s, n) => s + n, 100);
        expect(total).toBe(145);
      });
    });
  });
  describe('destructuring stuff', () => {
    it('allows you to destructure arrays', () => {
      const friends = ['Sean', 'Lee', 'Jamie', 'Henry', 'Violet'];

      // const friend0 = friends[0];
      // const friend2 = friends[2];
      const [friend0, , friend2, ...rest] = friends;

      expect(friend0).toBe('Sean');
      expect(friend2).toBe('Jamie');
      expect(rest).toEqual(['Henry', 'Violet']);
    });
    it('has object destructuring', () => {
      const starwars = {
        title: 'Star Wars',
        director: 'Lucas',
        yearReleased: 1977,
        cast: [{ name: 'Mark Hammil', role: 'Luke Skywalker' }],
      };

      // const title = starwars.title;
      // const yearReleased = starwars.yearReleased;
      const { title, yearReleased, director: directedBy } = starwars;

      expect(title).toBe('Star Wars');
      expect(directedBy).toBe('Lucas');
      expect(yearReleased).toBe(1977);
    });
  });
});
