export class Response<T> {
  statusResult: string;
  value: T;
}
export class CollectionResponse<T> {
  case: string;
  fields: Array<T[]>;

  values = this.fields[0];
}
