export interface IItemListing {
  ItemId: number;
  ItemNumber: string;
  ClarkItemNumberId: number;
  BaseClarkItemNumberId: number;
  QualifyingItemText: string;
  IsPerishable: boolean;
  IsORMD: boolean;
  IsHazardous: boolean;
  IsAvailable: boolean;
  IsWebPlusEligible: boolean;
  IdsItemId: number;
  NominalWeight: number;
  ItemGroupId: number;
  Cost: number;
  IsNonApproved: boolean;
  IsTaxable: boolean;
  UnitPrice: number;
  SalePrice: number;
  Image: string;
  Thumbnail: string;
  HoverImage: string;
  FullImageUri: string;
  FullThumbnailUri: string;
  HoverImageUri: string;
  Description: string;
  UnitOfMeasureId: number;
  OrderBy: number;
  HasAccessories: boolean;
  //DeliveryOrderCutoffDomainModel DeliveryOrderCutoff { get; set; }

  //ItemGroupDomainModel ItemGroup { get; set; }


  //UnitOfMeasureDomainModel UnitOfMeasure { get; set; }

  //IEnumerable < CustomItemDomainModel > CustomItems { get; set; }


  //BadgeDomainModel Badge { get; set; }

  //BrandDomainModel Brand { get; set; }

  //ShippingInformationDomainModel ShippingInformation { get; set; }
  //IReadOnlyCollection < ItemSpecDomainModel > Specs { get; set; }
  //PurchaseMinimumDomainModel PurchaseMinimum { get; set; } = new PurchaseMinimumDomainModel();

}
