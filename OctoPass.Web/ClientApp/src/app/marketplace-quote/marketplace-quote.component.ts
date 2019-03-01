import { Component, Inject } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { IQuote } from '../models/quotes/quote';
import { Response } from '../models/http/response';

@Component({
  selector: 'app-marketplace-quote-component',
  templateUrl: './marketplace-quote.component.html',
  styleUrls: ['./marketplace-quote.component.css']
})
export class MarketplaceQuoteComponent {
  public quote: IQuote;
  public selectedQuoteId: number;
  public retrievingQuote: boolean;
  public errorMessage: string;
  public retrievalMessage: string;

  constructor(private http: HttpClient, @Inject('API_BASE_URL') private baseApiUrl: string) {
  }

  retrieveQuote(): void {
    this.errorMessage = null;
    this.retrievingQuote = true;
    this.retrievalMessage = null;

    this.http.get<Response<IQuote>>(this.baseApiUrl + 'api/quotes/' + this.selectedQuoteId.toString()).subscribe(
      result => {
        this.quote = result.value;
        this.retrievalMessage = result.statusResult;
        this.retrievingQuote = false;
      }, (error: IError) => {
        console.error(error);
        this.errorMessage = error.error.text;
        this.retrievingQuote = false;
      });
  }

  clearStatuses() {
    this.errorMessage = null;
    this.retrievingQuote = false;
    this.retrievalMessage = null;
  }
}

interface IError {
  error: IErrorText;
}
interface IErrorText {
  text: string;
}
//interface IResponse<T> {
//  Data: T;
//  Errors: string[];
//  Message: string;
//  Status: string;
//}

//interface IQuoteResponse {
//  jsonValue: IQuote;
//}
