import { Component, Inject } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';

@Component({
  selector: 'app-marketplace-quote-component',
  templateUrl: './marketplace-quote.component.html'
})
export class MarketplaceQuoteComponent {
  public quote: IQuote;

  constructor(http: HttpClient, @Inject('API_BASE_URL') baseUrl: string) {
    
    http.get<IQuote>(baseUrl + 'api/quotes/1').subscribe(result => {
      this.quote = result;
      console.log(this.quote.Name)
    }, error => console.error(error));
  }
}

interface IResponse<T> {
  case: string;
  fields: Array<T>
}
export class IQuote {
  QuoteId: number;
  Name: string;
  ExpirationDate: Date;
  AccountId: number;
  ListId: number;
  OrderHeaderId: number;
  PricingLocationId: number;
  QuoteStatusId: number;
  ShippingAccountAddressId: number;
  DateCreated: Date;
  DateUpdated: Date;
  DateDeleted: Date;
  TaxCodeAndRateId: number;
  Tax?: number;
  TaxErrorMessage: string;
  LineItemCount: number;
  ClarkAccountId: number;
};
