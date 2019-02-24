namespace OctoPass

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.HttpsPolicy;
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.DependencyInjection
open Microsoft.AspNetCore.Cors.Infrastructure
open OctoPass.Repository
open System.Data
open System.Data.SqlClient

type Startup private () =
    new (configuration: IConfiguration) as this =
        Startup() then
        this.Configuration <- configuration
    
    // This method gets called by the runtime. Use this method to add services to the container.
    member this.ConfigureServices(services: IServiceCollection) =
        let corsPolicyBuilder = CorsPolicyBuilder();
        let corsPolicy = corsPolicyBuilder.WithOrigins("https://localhost:44375").Build()

        // Add framework services.
        services.AddScoped<IWeatherConditionRepository, WeatherConditionRepository>() |> ignore
        services.AddSingleton<IDbConnection>(new SqlConnection(this.Configuration.GetConnectionString("DefaultConnection"))) |> ignore
        services.AddCors(fun x -> x.AddPolicy("AllowWebFrontEnd", corsPolicy)) |> ignore
        services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2) |> ignore

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    member this.Configure(app: IApplicationBuilder, env: IHostingEnvironment) =
        if (env.IsDevelopment()) then
            app.UseDeveloperExceptionPage() |> ignore
        else
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts() |> ignore

        app.UseCors("AllowWebFrontEnd") |> ignore
        app.UseHttpsRedirection() |> ignore
        app.UseMvc() |> ignore

    member val Configuration : IConfiguration = null with get, set
