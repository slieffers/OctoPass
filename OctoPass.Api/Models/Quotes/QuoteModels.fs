module QuoteModels

open System

type QuoteItem = {
    ItemId: int;
    ItemNumber: string;
    Description: string;
    IsAvailable: bool;
}

type QuoteListItem = {
    ItemId: int;
    IdsItemId: int;
    Quantity: int;
    SortOrder: int;
    TotalPrice: decimal;
    ItemPrice: decimal;
    Cost: decimal;
    TotalCost: decimal;

    Item: QuoteItem;
}

type QuoteList = {
    Name: string;
    SortOrder: int;

    ListItems: seq<QuoteListItem>;
}

type Quote = {
    QuoteId : int;
    Name : string;
    ExpirationDate: DateTime;
    AccountId : int;
    FormattedAddress: string;
    OrderHeaderId: int;
    Tax: decimal;
    TaxErrorMessage: string;
    LineItemCount: int;
    PricingLocation: string;
    SelectedShippingCalculation: string;
    InternalComments: string;
    ExternalNotes: string;
    QuoteStatus: string;
    ClarkAssociate: string;

    List: QuoteList;
}
