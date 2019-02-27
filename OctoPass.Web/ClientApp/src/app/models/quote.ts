interface IQuote {
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
