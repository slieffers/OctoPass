module WeatherModels

type WeatherForecast (dateFormatted : string, temperatureC : int, summary : string)  =
    member this.DateFormatted with get () = dateFormatted
    member this.TemperatureC with get () = temperatureC
    member this.Summary with get () = summary

    member this.TemperatureF =
        (float 32 + float this.TemperatureC) / 0.5556 |> int
