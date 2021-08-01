using GildedRoseKata;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xunit;

namespace GildedRoseTests
{
    public class BackstagePassesRulesetTests
    {
        [Theory]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        public void WhenSellInIsBetweenSixAndTen_AndItemIsUpdated_QualityIncreasesFromOneToThree(
            int sellIn)
        {
            var item =  new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                Quality = 1,
                SellIn = sellIn,
            };
            var sut = new ItemUpdater(item);

            var newItem = sut.UpdateItem();

            Assert.Equal(3, newItem.Quality);
        }

        [Theory]
        [InlineData(48, 50)]
        [InlineData(10, 12)]
        [InlineData(1, 3)]
        [InlineData(0, 2)]
        public void WhenSellInIsTen_AndItemIsUpdated_QualityIncreasesByTwo(
            int initial,
            int expected)
        {
            var item = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                Quality = initial,
                SellIn = 10,
            };
            var sut = new ItemUpdater(item);

            var newItem = sut.UpdateItem();

            Assert.Equal(expected, newItem.Quality);
        }

        [Theory]
        [InlineData(48)]
        [InlineData(49)]
        [InlineData(50)]
        public void WhenSellInIsTen_AndQualityIsCloseToFifty_AndItemIsUpdated_QualityDoesNotPassFifty(
            int quality)
        {
            var item = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                Quality = quality,
                SellIn = 10,
            };
            var sut = new ItemUpdater(item);

            var newItem = sut.UpdateItem();

            Assert.Equal(50, newItem.Quality);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(4)]
        [InlineData(3)]
        [InlineData(2)]
        [InlineData(1)]
        public void WhenSellInIsBetweenOneAndFive_AndItemIsUpdated_QualityIncreasesFromOneToFour(
            int sellIn)
        {
            var item = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                Quality = 1,
                SellIn = sellIn,
            };
            var sut = new ItemUpdater(item);

            var newItem = sut.UpdateItem();

            Assert.Equal(4, newItem.Quality);
        }

        [Theory]
        [InlineData(47, 50)]
        [InlineData(10, 13)]
        [InlineData(1, 4)]
        [InlineData(0, 3)]
        public void WhenSellInIsFive_AndItemIsUpdated_QualityIncreasesByThree(
            int initial,
            int expected)
        {
            var item = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                Quality = initial,
                SellIn = 5,
            };
            var sut = new ItemUpdater(item);

            var newItem = sut.UpdateItem();

            Assert.Equal(expected, newItem.Quality);
        }

        [Theory]
        [InlineData(47)]
        [InlineData(48)]
        [InlineData(49)]
        [InlineData(50)]
        public void WhenSellInIsFive_AndQualityIsCloseToFifty_AndItemIsUpdated_QualityDoesNotPassFifty(
            int quality)
        {
            var item = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                Quality = quality,
                SellIn = 5,
            };
            var sut = new ItemUpdater(item);

            var newItem = sut.UpdateItem();

            Assert.Equal(50, newItem.Quality);
        }

        [Theory]
        [InlineData(50)]
        [InlineData(10)]
        [InlineData(1)]
        [InlineData(0)]
        public void WhenSellInIsZero_AndItemIsUpdated_QualityBecomesZero(
            int quality)
        {

            var item = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                Quality = quality,
                SellIn = 0,
            };
            var sut = new ItemUpdater(item);

            var newItem = sut.UpdateItem();

            Assert.Equal(0, newItem.Quality);
        }

        [Fact]
        public void WhenItemIsUpdated_NewObjectIsReturned()
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert" };
            var sut = new ItemUpdater(item);

            var newItem = sut.UpdateItem();

            Assert.NotSame(item, newItem);
        }

        [Fact]
        public void When100000ItemsAreUpdated_ItTakesLessThan200Ms()
        {
            var stopwatch = new Stopwatch();
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert" };
            var sut = new ItemUpdater(item);

            stopwatch.Start();
            for (var i = 0; i < 100000; i++)
            {
                sut.UpdateItem();
            }
            stopwatch.Stop();

            Assert.InRange(stopwatch.ElapsedMilliseconds, 0, 200);
        }
    }
}
