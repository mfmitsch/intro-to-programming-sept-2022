import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-shopping-list',
  templateUrl: './shopping-list.component.html',
  styleUrls: ['./shopping-list.component.css'],
})
export class ShoppingListComponent {
  shoppingList: ShoppingItem[] = [
    {
      description: 'Beer',
      purchased: false,
    },
  ];

  get noPurchasedItems() {
    return this.shoppingList.filter((item) => item.purchased).length === 0;
  }

  removePurchased() {
    this.shoppingList = this.shoppingList.filter((item) => !item.purchased);
  }

  markPurchased(item: ShoppingItem) {
    item.purchased = true;
  }

  addItem(item: HTMLInputElement) {
    const newItem: ShoppingItem = {
      description: item.value,
      purchased: false,
    };
    this.shoppingList.push(newItem);
    item.value = '';
    item.focus();
  }
}

type ShoppingItem = {
  description: string;
  purchased: boolean;
};
