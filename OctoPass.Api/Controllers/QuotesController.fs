namespace OctoPass.Controllers

open System
open Microsoft.AspNetCore.Mvc
open System.Net.Http
open QuoteModels
open FSharp.Data

[<Route("api/[controller]")>]
[<ApiController>]
type QuotesController () =
    inherit ControllerBase()

    [<HttpGet>]
    member this.Get() =
        let values = [|"value1"; "value2"|]
        ActionResult<string[]>(values)

    [<HttpGet("{id}")>]
    member this.Get(id:int) =
        use client = new HttpClient()
        client.BaseAddress <- Uri("http://localhost:51335/")
        let response = client.GetAsync("/api/quotes/octopass/" + (string id)) |> Async.AwaitTask |> Async.RunSynchronously
        let quote = response.Content.ReadAsStringAsync() |> Async.AwaitTask |> Async.RunSynchronously

        OkObjectResult(quote)

    [<HttpPost>]
    member this.Post([<FromBody>] value:string) =
        ()

    [<HttpPut("{id}")>]
    member this.Put(id:int, [<FromBody>] value:string ) =
        ()

    [<HttpDelete("{id}")>]
    member this.Delete(id:int) =
        ()
