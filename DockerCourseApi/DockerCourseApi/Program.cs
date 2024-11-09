using System.Data.SqlClient;
using Dapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

var app = builder.Build();

app.UseCors(cors => cors.AllowAnyOrigin());

app.MapGet("/podcasts", async () =>
{
    try
    {
        //var d = await System.Net.Dns.GetHostAddressesAsync("bal-sqldev16.fundassist.local");
        //SqlConnection connection1 = new("Server=bal-sqldev16.fundassist.local;Database=Reports;User Id = ApplicationUser;Password=T3st~2016;Persist Security Info=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");
        //return (await connection1.QueryAsync<Entity>("SELECT * FROM tblentities")).Select(x => x.EntityName);

        SqlConnection connection = new("Server=database;Initial Catalog=podcasts;Persist Security Info=False;User ID=sa;Password=Password1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");
        return (await connection.QueryAsync<Podcast>("SELECT * FROM Podcasts")).Select(x => x.Title);
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
        throw;
    }
});

await app.RunAsync();

public record struct Podcast(Guid Id, string Title);

public record struct Entity(long EntityID, string EntityName);
