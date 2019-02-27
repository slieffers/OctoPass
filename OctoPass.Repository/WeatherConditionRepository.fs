module OctoPass.Repository

open System.Data
open FSharp.Data

[<Literal>]
let connectionString = @"Data Source=.;Initial Catalog=OctoPass;Integrated Security=True"
[<Literal>]
let sql = "SELECT * FROM dbo.WeatherCondition"
type WeatherConditionRecords = SqlCommandProvider<sql, connectionString, ResultType.Records>

//type WeatherCondition = {
//        WeatherConditionId : int;
//        Description : string
//    }
//type IWeatherConditionRepository =
//    abstract getConditionsAsync : Async<list<WeatherCondition>>


type WeatherConditionRepository = // (connection : IDbConnection) =
    //interface IWeatherConditionRepository with
        static member getConditionsAsync =
            async{
                use queryWeatherConditions = new WeatherConditionRecords(connectionString)            

                //if connection.State <> ConnectionState.Open then connection.Open()
                let! result = queryWeatherConditions.AsyncExecute()
                //let entities = result |> Seq.map(fun el -> { WeatherConditionId = el.WeatherConditionId; Description = el.Description })
                return result |> List.ofSeq
                //let sql = "SELECT * FROM dbo.WeatherCondition"
                //let! result = connection.QueryAsync<WeatherCondition>(sql) |> Async.AwaitTask
                //return result |> List.ofSeq
            }