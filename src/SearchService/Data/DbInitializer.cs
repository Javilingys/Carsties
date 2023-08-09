using MongoDB.Driver;
using MongoDB.Entities;

namespace SearchService;

public static class DbInitializer
{
    public static async Task InitializeDb(WebApplication app)
    {
        await DB.InitAsync("SearchDb", MongoClientSettings
            .FromConnectionString(app.Configuration.GetConnectionString("MongoDbConnection")));

        // compound index
        await DB.Index<Item>()
            .Key(x => x.Make, KeyType.Text)
            .Key(x => x.Model, KeyType.Text)
            .Key(x => x.Color, KeyType.Text)
            .CreateAsync();

        var count = await DB.CountAsync<Item>();

        using var scope = app.Services.CreateScope();

        var httpClient = scope.ServiceProvider.GetRequiredService<AuctionSvcHttpClient>();

        var newItems = await httpClient.GetItemsAsync();

        Console.WriteLine($"{newItems.Count} returned from the Auction Service");

        if (newItems.Count > 0) 
        {
            await DB.SaveAsync(newItems);
        }
    }
}
