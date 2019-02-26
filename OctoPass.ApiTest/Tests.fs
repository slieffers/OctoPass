module Tests

open Xunit
open Moq.AutoMock
open OctoPass.Controllers
open OctoPass.Repository
open WeatherModels

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
                        { WeatherConditionId = i; Description = weatherDescriptions.[i] } } |> List.ofSeq
    mockRepo
        .Setup(fun x -> x.getConditionsAsync)
        .Returns(async{return sequence}) |> ignore

    let controller = mock.CreateInstance<SampleDataController>()
    let response = controller.WeatherForecasts()
    match response with
    | Ok value -> Assert.NotEmpty(value)
                  Assert.Equal(5, Seq.length value)
                  Assert.False(Seq.exists (fun (element : WeatherForecast) -> element.Summary.Length < 1) value)
    | Error e -> Assert.IsType(typeof<seq<WeatherForecast>>, e)
