import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: WeatherForecast[];

  constructor(http: HttpClient, @Inject('API_BASE_URL') baseUrl: string) {
    http.get<Response<WeatherForecast>>(baseUrl + 'api/SampleData/WeatherForecasts').subscribe(result => {
      if (result.case === 'Ok') {
        this.forecasts = result.fields[0];
      }
    }, error => console.error(error));
  }
}

interface WeatherForecast {
  dateFormatted: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

interface Response<T> {
  case: string;
  fields: Array<T[]>
}
