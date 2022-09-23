import { ShoppingListComponent } from './shopping-list.component';

describe('The SHopping List', () => {
  it('has one item', () => {
    const component = new ShoppingListComponent();
    expect(component.shoppingList.length).toBe(1);

    const firstItem = component.shoppingList[0].description;
    expect(firstItem).toBe('Beer');
  });
});
