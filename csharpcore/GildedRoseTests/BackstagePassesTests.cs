using GildedRoseKata;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GildedRoseTests
{
    public class BackstagePassesTests
    {
        [Theory]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        public void WhenSellInIsBetweenSixAndTen_AndOneDayPasses_QualityIncreasesFromOneToThree(
            int sellIn)
        {
            var items = new List<Item>
            {
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    Quality = 1,
                    SellIn = sellIn,
                },
            };
            var sut = new GildedRose(items);

            sut.UpdateQuality();

            Assert.Equal(3, items.First().Quality);
        }

        [Theory]
        [InlineData(48, 50)]
        [InlineData(10, 12)]
        [InlineData(1, 3)]
        [InlineData(0, 2)]
        public void WhenSellInIsTen_AndOneDayPasses_QualityIncreasesByTwo(
            int initial,
            int expected)
        {
            var items = new List<Item>
            {
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    Quality = initial,
                    SellIn = 10,
                },
            };
            var sut = new GildedRose(items);

            sut.UpdateQuality();

            Assert.Equal(expected, items.First().Quality);
        }

        [Theory]
        [InlineData(48)]
        [InlineData(49)]
        [InlineData(50)]
        public void WhenSellInIsTen_AndQualityIsCloseToFifty_AndOneDayPasses_QualityDoesNotPassFifty(
            int quality)
        {
            var items = new List<Item>
            {
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    Quality = quality,
                    SellIn = 10,
                },
            };
            var sut = new GildedRose(items);

            sut.UpdateQuality();

            Assert.Equal(50, items.First().Quality);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(4)]
        [InlineData(3)]
        [InlineData(2)]
        [InlineData(1)]
        public void WhenSellInIsBetweenOneAndFive_AndOneDayPasses_QualityIncreasesFromOneToFour(
            int sellIn)
        {
            var items = new List<Item>
            {
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    Quality = 1,
                    SellIn = sellIn,
                },
            };
            var sut = new GildedRose(items);

            sut.UpdateQuality();

            Assert.Equal(4, items.First().Quality);
        }

        [Theory]
        [InlineData(47, 50)]
        [InlineData(10, 13)]
        [InlineData(1, 4)]
        [InlineData(0, 3)]
        public void WhenSellInIsFive_AndOneDayPasses_QualityIncreasesByThree(
            int initial,
            int expected)
        {
            var items = new List<Item>
            {
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    Quality = initial,
                    SellIn = 5,
                },
            };
            var sut = new GildedRose(items);

            sut.UpdateQuality();

            Assert.Equal(expected, items.First().Quality);
        }

        [Theory]
        [InlineData(47)]
        [InlineData(48)]
        [InlineData(49)]
        [InlineData(50)]
        public void WhenSellInIsFive_AndQualityIsCloseToFifty_AndOneDayPasses_QualityDoesNotPassFifty(
            int quality)
        {
            var items = new List<Item>
            {
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    Quality = quality,
                    SellIn = 5,
                },
            };
            var sut = new GildedRose(items);

            sut.UpdateQuality();

            Assert.Equal(50, items.First().Quality);
        }

        [Theory]
        [InlineData(50)]
        [InlineData(10)]
        [InlineData(1)]
        [InlineData(0)]
        public void WhenSellInIsZero_AndOneDayPasses_QualityBecomesZero(
            int quality)
        {
            var items = new List<Item>
            {
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    Quality = quality,
                    SellIn = 0,
                },
            };
            var sut = new GildedRose(items);

            sut.UpdateQuality();

            Assert.Equal(0, items.First().Quality);
        }

        [Theory]
        [InlineData(50)]
        [InlineData(10)]
        [InlineData(1)]
        [InlineData(0)]
        public void WhenSellInIsOne_AndTwoDaysPass_QualityBecomesZero(
            int quality)
        {
            var items = new List<Item>
            {
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    Quality = quality,
                    SellIn = 1,
                },
            };
            var sut = new GildedRose(items);

            sut.UpdateQuality();
            sut.UpdateQuality();

            Assert.Equal(0, items.First().Quality);
        }
    }
}
