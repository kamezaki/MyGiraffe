namespace WebGiraffe

open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.DependencyInjection
open Giraffe

module routes =
    let webApp =
        choose [
            route "/ping"     >=> text "pong"
            route "/forecast" >=> warbler (fun _ -> Successful.OK (WeatherForecast.randomForecast()))
            // If none of the routes matched then return a 404
            RequestErrors.NOT_FOUND "Not Found"
        ]

module Configure =
    let configureApp (app : IApplicationBuilder) =
        // Add Giraffe to the ASP.NET Core pipeline
        app.UseGiraffe routes.webApp

    let configureServices (services : IServiceCollection) =
        // Add Giraffe dependencies
        services.AddGiraffe() |> ignore
