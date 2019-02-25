namespace WeatherServices

open System
open OctoPass.Repository
open WeatherModels

type IWeatherForecastService =
    abstract member assembleWeatherForecasts : seq<WeatherForecast>

type WeatherForecastService(weatherConditionRepository : IWeatherConditionRepository) =
    interface IWeatherForecastService with
        member this.assembleWeatherForecasts =
            let conditionsTask = weatherConditionRepository.getConditionsAsync |> Async.StartAsTask
            let rng = new Random();
            conditionsTask.Wait()
            seq { for i in 1..5 -> WeatherForecast(DateTime.Now.AddDays((float i)).ToString("d"), rng.Next(-20, 55), conditionsTask.Result.Item(rng.Next(conditionsTask.Result.Length)).Description) }
