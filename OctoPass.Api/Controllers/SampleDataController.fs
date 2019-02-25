namespace OctoPass.Controllers

open Microsoft.AspNetCore.Mvc
open WeatherServices

[<Route("api/[controller]")>]
[<ApiController>]
type SampleDataController (weatherForecastService : IWeatherForecastService) =
    inherit ControllerBase()
    
    [<HttpGet("[action]")>]
        member this.WeatherForecasts() : OkObjectResult =
            OkObjectResult(weatherForecastService.assembleWeatherForecasts)
