namespace ExploreCompoentBaseReplace.Client

open Microsoft.AspNetCore.Components.WebAssembly.Hosting
open Microsoft.Extensions.DependencyInjection
open System
open System.Net.Http

module Program =

    [<EntryPoint>]
    let Main args =
        let builder = WebAssemblyHostBuilder.CreateDefault(args)
        
        //easy change between C# and F# - comment/uncomment to set.
        builder.RootComponents.Add<ClassLibrary1.Rating2>("#main") //C# version
        //builder.RootComponents.Add<Fhash.AppComponent>("#main") //F# version //not working!
        
        builder.Services.AddScoped<HttpClient>(fun _ ->
            new HttpClient(BaseAddress = Uri builder.HostEnvironment.BaseAddress)) |> ignore
        builder.Build().RunAsync() |> ignore
        0
