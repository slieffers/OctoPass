import { Component, Inject, Input } from '@angular/core';
import { IListItem } from '../models/lists/listitem';

@Component({
  selector: 'app-marketplace-quote-details-list-item-component',
  templateUrl: './marketplace-quote-details-list-item.component.html'
})
export class MarketplaceQuoteDetailsListItemComponent {
  @Input() listItem: IListItem;

  constructor() {
  }

}
