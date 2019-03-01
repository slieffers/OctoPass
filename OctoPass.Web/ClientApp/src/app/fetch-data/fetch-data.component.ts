import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CollectionResponse } from '../models/http/response';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: IWeatherForecast[];

  constructor(http: HttpClient, @Inject('API_BASE_URL') baseUrl: string) {
    http.get<CollectionResponse<IWeatherForecast>>(baseUrl + 'api/SampleData/WeatherForecasts').subscribe(result => {
      if (result.case === 'Ok') {
        this.forecasts = result.values;
      }
    }, error => console.error(error));
  }
}

interface IWeatherForecast {
  dateFormatted: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

