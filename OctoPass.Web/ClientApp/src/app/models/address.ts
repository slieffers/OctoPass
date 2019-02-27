//module QuoteModels

//open System

//type QuoteModel () =
//    member val QuoteId : int = 0 with get, set
//    member val Name : string = "" with get, set
//    member val ExpirationDate : DateTime option = None with get, set
//    member val AccountId : int = 0 with get, set
//    member val ListId : int = 0 with get, set
//    member val OrderHeaderId : int option = None with get, set
//    member val PricingLocationId : int = 0 with get, set
//    member val QuoteStatusId : int = 0 with get, set
//    member val ShippingAccountAddressId : int = 0 with get, set

//    member val DateCreated : DateTime = DateTime.MinValue with get, set
//    member val DateUpdated : DateTime = DateTime.MinValue with get, set
//    member val DateDeleted : DateTime option = None with get, set

//    member val TaxCodeAndRateId : int = 0 with get, set
//    member val Tax : decimal option = None with get, set
//    member val TaxErrorMessage : string = "" with get, set
//    //member val AddressWithRelationshipsDomainModel ShippingAddress with get, set
//    //member val QuoteShippingCalculationDomainModel ShippingCalculation with get, set = new QuoteShippingCalculationDomainModel();
//    //member val QuoteStatusDomainModel Status with get, set
//    //member val int LineItemCount : int = 0 with get, set

//    //member val ShippingOptionsDomainModel ShippingOptions with get, set
        
//    //member val QuoteListDomainModel List with get, set

//    //member val IEnumerable<CommentWithTypeDomainModel> Comments with get, set =
//    //    new List<CommentWithTypeDomainModel>();

//    //member val QuotesTotalCollectionDomainModel TotalCollection =>
//    //    new QuotesTotalCollectionDomainModel(List.ListItems, List.CustomListItems, ShippingCalculation?.Cost ?? 0.00M, ShippingCalculation?.Price ?? 0.00M, Tax ?? 0);

//    //member val short ClarkAccountId with get, set
//    //member val ClarkAccountDomainModel ClarkAccount with get, set
