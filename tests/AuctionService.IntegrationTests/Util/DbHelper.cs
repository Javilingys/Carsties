using AuctionService.Data;
using AuctionService.Entities;

namespace AuctionService.IntegrationTests;

public static class DbHelper
{
    public static void InitDbForTests(AuctionDbContext db) 
    {
        db.Auctions.AddRange(GetAuctionsForTest());
        db.SaveChanges();
    }

    public static void ReinitDbForTests(AuctionDbContext db) 
    {
        db.Auctions.RemoveRange(db.Auctions);
        db.SaveChanges();
        InitDbForTests(db);
    }

    private static List<Auction> GetAuctionsForTest() 
    {
        return new List<Auction> 
        {
            // 1 Ford GT
            new Auction
            {
                Id = Guid.Parse("afbee524-5972-4075-8800-7d1f9d7b0a0c"),
                Status = Status.Live,
                ReservePrice = 20000,
                Seller = "bob",
                AuctionEnd = DateTime.UtcNow.AddDays(10),
                Item = new Item
                {
                    Make = "Ford",
                    Model = "GT",
                    Color = "White",
                    Mileage = 50000,
                    Year = 2020,
                    ImageUrl = "https://sun9-53.userapi.com/impg/Pfo48pCfOLmQ-aoWYad2WO_Pca2NIKeVDNByHA/9uQiGfArLvE.jpg?size=1600x1155&quality=95&sign=839048762cc49ae2084f3508c3df737a&type=album"
                }
            },
            // 2 Bugatti Veyron
            new Auction
            {
                Id = Guid.Parse("c8c3ec17-01bf-49db-82aa-1ef80b833a9f"),
                Status = Status.Live,
                ReservePrice = 90000,
                Seller = "alice",
                AuctionEnd = DateTime.UtcNow.AddDays(60),
                Item = new Item
                {
                    Make = "Bugatti",
                    Model = "Veyron",
                    Color = "Black",
                    Mileage = 15035,
                    Year = 2018,
                    ImageUrl = "https://sun1-21.userapi.com/impg/6cq2Dd02x3nHH8ITeiGZLkl0YkCbG1E_kU2HTw/7YAimjHiRuw.jpg?size=1179x1150&quality=96&sign=211df444ff06868bd7677f888892bb77&type=album"
                }
            },
            // 3 Ford mustang
            new Auction
            {
                Id = Guid.Parse("bbab4d5a-8565-48b1-9450-5ac2a5c4a654"),
                Status = Status.Live,
                Seller = "bob",
                AuctionEnd = DateTime.UtcNow.AddDays(4),
                Item = new Item
                {
                    Make = "Ford",
                    Model = "Mustang",
                    Color = "Black",
                    Mileage = 65125,
                    Year = 2023,
                    ImageUrl = "https://sun9-60.userapi.com/impg/SkulIxosqQl13u0vgvXU0Bz-0cLu7nS8kWKKmw/7r3-1j0Ex7o.jpg?size=1000x562&quality=95&sign=8a6d218eb5062c6c63bdaae1e6b0c50a&type=album"
                }
            }
        };
    }
}
