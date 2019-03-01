import { IList } from "../lists/list";

export interface IQuote {
  quoteId: number;
  name: string;
  expirationDate: Date;
  accountId: number;
  listId: number;
  orderHeaderId: number;
  pricingLocationId: number;
  quoteStatusId: number;
  shippingAccountAddressId: number;
  dateCreated: Date;
  dateUpdated: Date;
  dateDeleted: Date;
  taxCodeAndRateId: number;
  tax?: number;
  taxErrorMessage: string;
  lineItemCount: number;
  clarkAccountId: number;
  pricingLocation: string;
  selectedShippingCalculation: string;
  internalComments: string;
  externalNotes: string;
  quoteStatus: string;
  formattedAddress: string;

  list: IList;
};
