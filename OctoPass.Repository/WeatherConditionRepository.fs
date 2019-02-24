namespace OctoPass.Repository

open Dapper
open System.Data

type WeatherCondition(weatherConditionId : int, description : string) =
    member val WeatherConditionId = weatherConditionId with get, set
    member val Description = description with get, set

type IWeatherConditionRepository =
    abstract getConditions : list<WeatherCondition>

type WeatherConditionRepository (connection : IDbConnection) =
    interface IWeatherConditionRepository with
        member this.getConditions =
            if connection.State <> ConnectionState.Open then connection.Open()
            let sql = "SELECT * FROM dbo.WeatherCondition"
            connection.Query<WeatherCondition>(sql) |> List.ofSeq