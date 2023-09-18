using AuctionService.Entities;

namespace AuctionService.UnitTests;

public class AuctionEntityTests
{
    //Method_Scenario_ExpectedResult
    [Fact]
    public void HasReservePrice_ReservePriceGtZEro_True()
    {
        // arrange
        var auction = new Auction
        {
            Id = Guid.NewGuid(),
            ReservePrice = 10
        };

        // act
        var result = auction.HasReservePrice();

        // assert
        Assert.True(result);
    }

    [Fact]
    public void HasReservePrice_ReservePriceIsZEro_False()
    {
        // arrange
        var auction = new Auction
        {
            Id = Guid.NewGuid(),
            ReservePrice = 0
        };

        // act
        var result = auction.HasReservePrice();

        // assert
        Assert.False(result);
    }
}