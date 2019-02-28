import { IItemListing } from "../items/itemlisting";
import { IListItemPrice } from "./listitemprice";

export interface IListItem {
  ListItemId: number;
  ListId: number;
  ItemId: number;
  IdsItemId: number;
  Quantity: number;
  SortOrder: number;
  TotalPrice: number;
  Price: IListItemPrice;
  //public virtual ListItemFreeShippingDomainModel FreeShipping { get; set; }

  Item: IItemListing;

  //public virtual CommentDomainModel Comment { get; set; }
}

export class ListItem implements IListItem {
  ListItemId: number;
  ListId: number;
  ItemId: number;
  IdsItemId: number;
  Quantity: number;
  SortOrder: number;
  TotalPrice: number;
  Price: IListItemPrice;
  Item: IItemListing;

  TotalCost: number = this.Quantity * this.Item.Cost;
}
