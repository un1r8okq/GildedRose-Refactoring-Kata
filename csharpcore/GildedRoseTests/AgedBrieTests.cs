using GildedRoseKata;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GildedRoseTests
{
    public class AgedBrieTests
    {
        [Theory]
        [InlineData(10, 11)]
        [InlineData(0, 1)]
        public void WhenSellInIsOne_AndOneDayPasses_QualityIncreasesByOne(
            int initial,
            int expected)
        {
            var items = new List<Item>
            {
                new Item
                {
                    Name = "Aged Brie",
                    Quality = initial,
                    SellIn = 1,
                },
            };
            var sut = new GildedRose(items);

            sut.UpdateQuality();

            Assert.Equal(expected, items.First().Quality);
        }

        [Theory]
        [InlineData(10, 12)]
        [InlineData(0, 2)]
        public void WhenSellInIsZero_AndOneDayPasses_QualityIncreasesByTwo(
            int initial,
            int expected)
        {
            var items = new List<Item>
            {
                new Item
                {
                    Name = "Aged Brie",
                    Quality = initial,
                    SellIn = 0,
                },
            };
            var sut = new GildedRose(items);

            sut.UpdateQuality();

            Assert.Equal(expected, items.First().Quality);
        }

        [Theory]
        [InlineData(10, 12)]
        [InlineData(0, 2)]
        public void WhenSellInIsNegativeOne_AndOneDayPasses_QualityIncreasesByTwo(
            int initial,
            int expected)
        {
            var items = new List<Item>
            {
                new Item
                {
                    Name = "Aged Brie",
                    Quality = initial,
                    SellIn = -1,
                },
            };
            var sut = new GildedRose(items);

            sut.UpdateQuality();

            Assert.Equal(expected, items.First().Quality);
        }

        [Fact]
        public void WhenSellInIsOne_AndQualityIsFifty_AndOneDayPasses_QualityDoesNotChange()
        {
            var items = new List<Item>
            {
                new Item
                {
                    Name = "Aged Brie",
                    Quality = 50,
                    SellIn = 1,
                },
            };
            var sut = new GildedRose(items);

            sut.UpdateQuality();

            Assert.Equal(50, items.First().Quality);
        }

        [Fact]
        public void WhenSellInIsZero_AndQualityIsFifty_AndOneDayPasses_QualityDoesNotChange()
        {
            var items = new List<Item>
            {
                new Item
                {
                    Name = "Aged Brie",
                    Quality = 50,
                    SellIn = 0,
                },
            };
            var sut = new GildedRose(items);

            sut.UpdateQuality();

            Assert.Equal(50, items.First().Quality);
        }
    }
}
