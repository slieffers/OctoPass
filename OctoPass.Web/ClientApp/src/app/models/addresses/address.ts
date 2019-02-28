import { ICity } from './city';
import { IZipCode } from './zipcode';
import { IStateProvince } from './stateprovince';

export interface IAddress {
  AddressId: number;
  Line1: string;
  Line2: string;
  FirstName: string;
  LastName: string;
  PhoneNumber: string;
  CityId: number;
  StateProvinceId: number;
  ZipCodeId: number;
  LocationName: string;
  FormattedAddress: string;

  City: ICity;
  StateProvince: IStateProvince;
  ZipCode: IZipCode;
}
