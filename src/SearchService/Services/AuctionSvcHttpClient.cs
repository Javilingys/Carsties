using MongoDB.Entities;

namespace SearchService;

public class AuctionSvcHttpClient
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    private readonly ILogger<AuctionSvcHttpClient> _logger;

    public AuctionSvcHttpClient(HttpClient httpClient, IConfiguration configuration, ILogger<AuctionSvcHttpClient> logger)
    {
            _logger = logger;
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<List<Item>> GetItemsAsync()
    {
        var lastUpdated = await DB.Find<Item, string>()
            .Sort(x => x.UpdatedAt, Order.Descending)
            .Project(x => x.UpdatedAt.ToString())
            .ExecuteFirstAsync();

        string searchString = string.IsNullOrEmpty(lastUpdated)
            ? "/api/auctions"
            : "/api/auctions?date=" + lastUpdated;

        Console.WriteLine($"--> URL: {_configuration["AuctionServiceUrl"] + searchString}");

        return await _httpClient.GetFromJsonAsync<List<Item>>(_configuration["AuctionServiceUrl"] + searchString);
    }
}
