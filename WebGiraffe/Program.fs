namespace WebGiraffe

open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Hosting
open Giraffe
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.DependencyInjection

module routes =
    let webApp =
        choose [
            route "/ping"     >=> text "pong"
            route "/forecast" >=> warbler (fun _ -> Successful.OK (WeatherForecast.randomForecast()))
            // If none of the routes matched then return a 404
            RequestErrors.NOT_FOUND "Not Found"
        ]

module configure =
    let configureApp (app : IApplicationBuilder) =
        // Add Giraffe to the ASP.NET Core pipeline
        app.UseGiraffe routes.webApp

    let configureServices (services : IServiceCollection) =
        // Add Giraffe dependencies
        services.AddGiraffe() |> ignore

module Program =

    [<EntryPoint>]
    let main _ =
        Host.CreateDefaultBuilder()
            .ConfigureWebHostDefaults(
                fun webHostBuilder ->
                    webHostBuilder
                        .Configure(configure.configureApp)
                        .ConfigureServices(configure.configureServices)
                        |> ignore)
            .Build()
            .Run()
        0
