import { IAddress } from "../addresses/address";

export interface IQuote {
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
  PricingLocation: string;
  SelectedShippingCalculation: string;
  InternalComments: string;
  ExternalNotes: string;
  QuoteStatus: string;

  ShippingAddress: IAddress;
};
