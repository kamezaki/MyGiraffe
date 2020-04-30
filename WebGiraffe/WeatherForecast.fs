namespace WebGiraffe

open System

module WeatherForecast =

    type WeatherForecast =
        { Date: DateTime
          TemperatureC: int
          Summary: string }

        member this.TemperatureF =
            32 + (int (float this.TemperatureC / 0.5556))

    let summaries = [| "Freezing"; "Bracing"; "Chilly"; "Cool"; "Mild"; "Warm"; "Balmy"; "Hot"; "Sweltering"; "Scorching" |]

    let randomForecast = fun _ ->
        let rng = Random()
        [|
            for index in 0..4 ->
                { Date = DateTime.Now.AddDays(float index)
                  TemperatureC = rng.Next(-20,55)
                  Summary = summaries.[rng.Next(summaries.Length)] }
        |]
