import { ListItem } from './listitem';

export interface IList {
  ListId: number;
  Name: string;
  SortOrder: number;

  ListItems: ListItem[];
  //public virtual List < QuoteCustomListItemDomainModel > CustomListItems { get; set; } = new List<QuoteCustomListItemDomainModel>();
}
