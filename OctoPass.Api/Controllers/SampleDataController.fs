namespace OctoPass.Controllers

open Microsoft.AspNetCore.Mvc
open System
open OctoPass.Repository

type WeatherForecast (dateFormatted : string, temperatureC : int, summary : string)  =
    member this.DateFormatted with get () = dateFormatted
    member this.TemperatureC with get () = temperatureC
    member this.Summary with get () = summary

    member this.TemperatureF =
        (float 32 + float this.TemperatureC) / 0.5556 |> int;

[<Route("api/[controller]")>]
[<ApiController>]
type SampleDataController (weatherConditionRepository : IWeatherConditionRepository) =
    inherit ControllerBase()

    //let Summaries = 
    //    [|
    //        "Freezing" 
    //        "Bracing" 
    //        "Chilly" 
    //        "Cool" 
    //        "Mild" 
    //        "Warm" 
    //        "Balmy" 
    //        "Hot" 
    //        "Sweltering" 
    //        "Scorching"
    //    |]

    [<HttpGet("[action]")>]
        member this.WeatherForecasts() : seq<WeatherForecast> =
            let conditions = weatherConditionRepository.getConditions
            let rng = new Random();
            seq { for i in 1..5 -> WeatherForecast(DateTime.Now.AddDays((float i)).ToString("d"), rng.Next(-20, 55), conditions.Item(rng.Next(conditions.Length)).Description) }
