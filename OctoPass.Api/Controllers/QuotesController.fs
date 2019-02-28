namespace OctoPass.Controllers

open Microsoft.AspNetCore.Mvc
open FSharp.Data

type jsonParser = JsonProvider<"http://localhost:51335/api/quotes/octopass/1">

type ApiCallResult = 
    | Good of OkObjectResult
    | Error of NotFoundObjectResult

type NotFound = {
        Status : string;
        Message : string;
        Errors : string[]
    }
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
        try
            jsonParser.AsyncLoad("http://localhost:51335/api/quotes/octopass/" + (string id)) |> Async.RunSynchronously |> string
        with
        | ex -> ex.InnerException.Message

    [<HttpPost>]
    member this.Post([<FromBody>] value:string) =
        ()

    [<HttpPut("{id}")>]
    member this.Put(id:int, [<FromBody>] value:string ) =
        ()

    [<HttpDelete("{id}")>]
    member this.Delete(id:int) =
        ()
