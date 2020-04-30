namespace WebGiraffe

open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Hosting

module Program =

    [<EntryPoint>]
    let main _ =
        Host.CreateDefaultBuilder()
            .ConfigureWebHostDefaults(
                fun webHostBuilder ->
                    webHostBuilder
                        .Configure(Configure.configureApp)
                        .ConfigureServices(Configure.configureServices)
                        |> ignore)
            .Build()
            .Run()
        0
