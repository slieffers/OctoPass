module Tests

open Xunit
open Moq.AutoMock
open OctoPass.Controllers
open OctoPass.Repository

[<Fact>]
let ``My test`` () =
    let mock = AutoMocker()
    let mockRepo = mock.GetMock<IWeatherConditionRepository>()
    let sequence = seq {for i in 1..10 -> WeatherCondition(i, "Description" + (string i))} |> List.ofSeq
    mockRepo
        .Setup(fun x -> x.getConditions)
        .Returns(sequence) |> ignore

    let controller = mock.CreateInstance<SampleDataController>()
    let result = controller.WeatherForecasts()

    Assert.NotEmpty(result)
    Assert.Equal(5, Seq.length result)
    Assert.False(Seq.exists (fun (element : WeatherForecast) -> element.Summary.Length < 1) result)
