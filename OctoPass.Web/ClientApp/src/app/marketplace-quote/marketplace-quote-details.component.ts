import { Component, Inject, Input } from '@angular/core';
import { IQuote } from '../models/quotes/quote';

@Component({
  selector: 'app-marketplace-quote-details-component',
  templateUrl: './marketplace-quote-details.component.html'
})
export class MarketplaceQuoteDetailsComponent {
  @Input() quote: IQuote;

  constructor() {
  }

}
