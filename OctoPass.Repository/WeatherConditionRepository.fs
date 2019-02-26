namespace OctoPass.Repository

open System.Data
open FSharp.Data

type WeatherCondition = {
        WeatherConditionId : int;
        Description : string
    }
type IWeatherConditionRepository =
    abstract getConditionsAsync : Async<list<WeatherCondition>>

type WeatherConditionRepository (connection : IDbConnection) =
    interface IWeatherConditionRepository with
        member this.getConditionsAsync =
            async{
                let connectionString = @"Data Source=.;Initial Catalog=OctoPass;Integrated Security=True"
                use cmd = new SqlCommandProvider<"SELECT * 
                                                  FROM dbo.WeatherCondition", 
                                                  @"Data Source=.;Initial Catalog=OctoPass;Integrated Security=True">(connectionString)
                //if connection.State <> ConnectionState.Open then connection.Open()
                let! result = cmd.AsyncExecute() 
                let entities = result |> Seq.map(fun el -> { WeatherConditionId = el.WeatherConditionId; Description = el.Description })
                //let entities = Seq.map(fun element -> WeatherCondition) result |> List.ofSeq
                return entities |> List.ofSeq
                //let sql = "SELECT * FROM dbo.WeatherCondition"
                //let! result = connection.QueryAsync<WeatherCondition>(sql) |> Async.AwaitTask
                //return result |> List.ofSeq
            }