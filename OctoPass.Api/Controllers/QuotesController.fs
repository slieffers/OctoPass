namespace OctoPass.Controllers

open Microsoft.AspNetCore.Mvc
open FSharp.Data
open System.Net.Http
open System
open QuoteModels
open Newtonsoft.Json

type jsonParser = JsonProvider<".\quote.json">
//type jsonParser = JsonProvider<"http://localhost:51335/api/quotes/octopass/1">

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
            //use client = new HttpClient()
            //client.BaseAddress <- Uri "http://localhost:51335/"
            //let quoteJson = client.GetStringAsync("api/quotes/octopass/") |> Async.AwaitTask |> Async.RunSynchronously
            let data = jsonParser.GetSample().Data
            let quote = JsonConvert.DeserializeObject<Quote>(data.JsonValue |> string)

            let listItems = 
                data.List.ListItems |> 
                    Seq.map(fun li -> {
                        IdsItemId = li.IdsItemId; 
                        SortOrder = li.SortOrder;
                        ItemId = li.ItemId; 
                        Quantity = li.Quantity; 
                        TotalPrice = li.TotalPrice; 
                        ItemPrice = li.Price.Price; 
                        Cost = li.Item.Cost;
                        TotalCost = (decimal li.Quantity) * li.Item.Cost;
                        Item = JsonConvert.DeserializeObject<QuoteItem>(li.Item.JsonValue |> string)
                    })

            let list = { quote.List with ListItems = listItems}

            let quoteRecord = { 
                quote with 
                    FormattedAddress = data.ShippingAddress.FormattedAddress; 
                    ClarkAssociate = data.ClarkAccount.FullName;
                    List = list;
            }

            quoteRecord |> OkObjectResult |> JsonResult
        with
        | ex -> ex.Message |> NotFoundObjectResult |> JsonResult

    [<HttpPost>]
    member this.Post([<FromBody>] value:string) =
        ()

    [<HttpPut("{id}")>]
    member this.Put(id:int, [<FromBody>] value:string ) =
        ()

    [<HttpDelete("{id}")>]
    member this.Delete(id:int) =
        ()
