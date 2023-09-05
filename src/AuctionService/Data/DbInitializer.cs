using AuctionService.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctionService.Data;

public static class DbInitializer
{
    public static void InitDb(WebApplication app) 
    {
        using var scope = app.Services.CreateScope();

        MigrateAndSeedData(scope.ServiceProvider.GetService<AuctionDbContext>());
    }

    private static void MigrateAndSeedData(AuctionDbContext context) 
    {
        context.Database.Migrate();

        if (context.Auctions.Any())
        {
            Console.WriteLine("Already have data - no need to seed");
            return;
        }

         var auctions = new List<Auction>()
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
            },
            // 4 Mercedes SLK
            new Auction
            {
                Id = Guid.Parse("155225c1-4448-4066-9886-6786536e05ea"),
                Status = Status.ReserveNotMet,
                ReservePrice = 50000,
                Seller = "tom",
                AuctionEnd = DateTime.UtcNow.AddDays(-10),
                Item = new Item
                {
                    Make = "Mercedes",
                    Model = "SLK",
                    Color = "Silver",
                    Mileage = 15001,
                    Year = 2020,
                    ImageUrl = "https://sun9-50.userapi.com/impg/JU1fOZlaSScOCHE8KqBoI30JixN4tZ9d8FJlvw/BKDr610TD8M.jpg?size=807x537&quality=95&sign=8c133d6c5c7a4e809b5f494cf5123d92&type=album"
                }
            },
            // 5 BMW X1
            new Auction
            {
                Id = Guid.Parse("466e4744-4dc5-4987-aae0-b621acfc5e39"),
                Status = Status.Live,
                ReservePrice = 20000,
                Seller = "alice",
                AuctionEnd = DateTime.UtcNow.AddDays(30),
                Item = new Item
                {
                    Make = "BMW",
                    Model = "X1",
                    Color = "White",
                    Mileage = 90000,
                    Year = 2017,
                    ImageUrl = "https://sun9-19.userapi.com/impg/lYSpBH4OM2_aXvmWSZXTmfKXx6Vna4yz1ooVnQ/lisgFIBcG-o.jpg?size=672x372&quality=95&sign=fd872f13333091c488a0ee470f49115f&type=album"
                }
            },
            // 6 Ferrari spider
            new Auction
            {
                Id = Guid.Parse("dc1e4071-d19d-459b-b848-b5c3cd3d151f"),
                Status = Status.Live,
                ReservePrice = 20000,
                Seller = "bob",
                AuctionEnd = DateTime.UtcNow.AddDays(45),
                Item = new Item
                {
                    Make = "Ferrari",
                    Model = "Spider",
                    Color = "Red",
                    Mileage = 50000,
                    Year = 2015,
                    ImageUrl = "https://sun9-28.userapi.com/impg/_fMNVjGzJ0XFXJFOBqdyK5yEVlB6ShsHPWR7bw/pJqq3z64GWk.jpg?size=1440x1800&quality=96&sign=0b54e155ff8598dddccbfcf33baa808e&type=album"
                }
            },
            // 7 Ferrari F-430
            new Auction
            {
                Id = Guid.Parse("47111973-d176-4feb-848d-0ea22641c31a"),
                Status = Status.Live,
                ReservePrice = 150000,
                Seller = "alice",
                AuctionEnd = DateTime.UtcNow.AddDays(13),
                Item = new Item
                {
                    Make = "Ferrari",
                    Model = "F-430",
                    Color = "Red",
                    Mileage = 5000,
                    Year = 2022,
                    ImageUrl = "https://sun9-48.userapi.com/impg/nSdgl7TxSJCzAESpcsIaDf9m4QoMldWOXEbdPg/GMwLeXU_Jgg.jpg?size=720x885&quality=95&sign=ada32195cd3d9991640d4c220dea1770&type=album"
                }
            },
            // 8 Audi R8
            new Auction
            {
                Id = Guid.Parse("6a5011a1-fe1f-47df-9a32-b5346b289391"),
                Status = Status.Live,
                Seller = "bob",
                AuctionEnd = DateTime.UtcNow.AddDays(19),
                Item = new Item
                {
                    Make = "Audi",
                    Model = "R8",
                    Color = "White",
                    Mileage = 10050,
                    Year = 2021,
                    ImageUrl = "https://sun9-39.userapi.com/impg/Qoav-et0BoWRXhHAbItC3P61mDW441IGGB9bMQ/B1BnOSZoWR0.jpg?size=960x952&quality=95&sign=1f008a271475d934e4a743cad8da27c4&type=album"
                }
            },
            // 9 Audi TT
            new Auction
            {
                Id = Guid.Parse("40490065-dac7-46b6-acc4-df507e0d6570"),
                Status = Status.Live,
                ReservePrice = 20000,
                Seller = "tom",
                AuctionEnd = DateTime.UtcNow.AddDays(20),
                Item = new Item
                {
                    Make = "Audi",
                    Model = "TT",
                    Color = "Black",
                    Mileage = 25400,
                    Year = 2020,
                    ImageUrl = "https://sun9-28.userapi.com/impg/_rb7Ds71zK4knTq2YgfEgWMX0kL3RjFXPjoGag/7HjLWRl5vNE.jpg?size=1170x1366&quality=95&sign=bf375aa11b29a3458a108ebb928c20cb&type=album"
                }
            },
            // 10 Ford Model T
            new Auction
            {
                Id = Guid.Parse("3659ac24-29dd-407a-81f5-ecfe6f924b9b"),
                Status = Status.Live,
                ReservePrice = 20000,
                Seller = "bob",
                AuctionEnd = DateTime.UtcNow.AddDays(48),
                Item = new Item
                {
                    Make = "Ford",
                    Model = "Model T",
                    Color = "Rust",
                    Mileage = 150150,
                    Year = 1938,
                    ImageUrl = "https://sun9-30.userapi.com/impg/4QPK3ibvab8XCSNkFpQWOQkOjP_rHPht2GPGVA/b68o6swbGsE.jpg?size=960x723&quality=95&sign=9452d409fc4943b4a3efcc00f7461d75&type=album"
                }
            }
        };

        context.AddRange(auctions);

        context.SaveChanges();
    }
}
