module Tests

open Xunit
open Moq.AutoMock
open OctoPass.Controllers
open OctoPass.Repository

let weatherDescriptions = 
    [|
        "Freezing" 
        "Bracing" 
        "Chilly" 
        "Cool" 
        "Mild" 
        "Warm" 
        "Balmy" 
        "Hot" 
        "Sweltering" 
        "Scorching"
    |]

[<Fact>]
let ``My test`` () =
    let mock = AutoMocker()
    let mockRepo = mock.GetMock<IWeatherConditionRepository>()
    let sequence = seq {for i in 0..weatherDescriptions.Length - 1 -> 
                        WeatherCondition(i, weatherDescriptions.[i])} |> List.ofSeq
    mockRepo
        .Setup(fun x -> x.getConditionsAsync)
        .Returns(async{return sequence}) |> ignore

    let controller = mock.CreateInstance<SampleDataController>()
    let result = controller.WeatherForecasts()

    Assert.NotEmpty(result)
    Assert.Equal(5, Seq.length result)
    Assert.False(Seq.exists (fun (element : WeatherForecast) -> element.Summary.Length < 1) result)
