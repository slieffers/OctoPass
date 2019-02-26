namespace OctoPass.Controllers

open Microsoft.AspNetCore.Mvc
open WeatherServices
open WeatherModels

[<Route("api/[controller]")>]
[<ApiController>]
type SampleDataController (weatherForecastService : IWeatherForecastService) =
    inherit ControllerBase()
    
    [<HttpGet("[action]")>]
        member this.WeatherForecasts() : Result<seq<WeatherForecast>, obj> =
            Ok(weatherForecastService.assembleWeatherForecasts)
