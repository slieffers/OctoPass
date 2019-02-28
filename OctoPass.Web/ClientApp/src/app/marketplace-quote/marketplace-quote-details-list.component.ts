import { Component, Inject, Input } from '@angular/core';
import { IList } from '../models/lists/list';

@Component({
  selector: 'app-marketplace-quote-details-list-component',
  templateUrl: './marketplace-quote-details-list.component.html',
  styleUrls: ['./marketplace-quote-details-list.component.css']
})
export class MarketplaceQuoteDetailsListComponent {
  @Input() list: IList;

  constructor() {
  }
}
