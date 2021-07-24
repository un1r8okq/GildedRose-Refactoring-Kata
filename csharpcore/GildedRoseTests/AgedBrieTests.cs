using GildedRoseKata;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GildedRoseTests
{
    public class AgedBrieTests
    {
        [Fact]
        public void UpdateQuality_SellInIsOne_QualityIncreasesByOne()
        {
            var items = new List<Item>
            {
                new Item
                {
                    Name = "Aged Brie",
                    SellIn = 1,
                    Quality = 1,
                },
            };
            var sut = new GildedRose(items);

            sut.UpdateQuality();

            Assert.Equal(2, items.First().Quality);
        }

        [Fact]
        public void UpdateQuality_SellInIsZero_QualityIncreasesByTwo()
        {
            var items = new List<Item>
            {
                new Item
                {
                    Name = "Aged Brie",
                    SellIn = 0,
                    Quality = 1,
                },
            };
            var sut = new GildedRose(items);

            sut.UpdateQuality();

            Assert.Equal(3, items.First().Quality);
        }

        [Fact]
        public void UpdateQuality_SellInIsOne_QualityIsFifty_QualityDoesNotChange()
        {
            var items = new List<Item>
            {
                new Item
                {
                    Name = "Aged Brie",
                    SellIn = 1,
                    Quality = 50,
                },
            };
            var sut = new GildedRose(items);

            sut.UpdateQuality();

            Assert.Equal(50, items.First().Quality);
        }

        [Fact]
        public void UpdateQuality_SellInIsNegativeOne_QualityIsFifty_QualityDoesNotChange()
        {
            var items = new List<Item>
            {
                new Item
                {
                    Name = "Aged Brie",
                    SellIn = -1,
                    Quality = 50,
                },
            };
            var sut = new GildedRose(items);

            sut.UpdateQuality();

            Assert.Equal(50, items.First().Quality);
        }
    }
}
