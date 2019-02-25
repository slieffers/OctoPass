namespace OctoPass.Repository

open Dapper
open System.Data

type WeatherCondition(weatherConditionId : int, description : string) =
    member this.WeatherConditionId with get () = weatherConditionId
    member this.Description with get () = description

type IWeatherConditionRepository =
    abstract getConditionsAsync : Async<list<WeatherCondition>>

type WeatherConditionRepository (connection : IDbConnection) =
    interface IWeatherConditionRepository with
        member this.getConditionsAsync =
            async{
                if connection.State <> ConnectionState.Open then connection.Open()
                let sql = "SELECT * FROM dbo.WeatherCondition"
                let! result = connection.QueryAsync<WeatherCondition>(sql) |> Async.AwaitTask
                return result |> List.ofSeq
            }