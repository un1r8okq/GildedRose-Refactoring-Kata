using GildedRoseKata;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GildedRoseTests
{
    public class ConjuredManaCakeTests
    {
        [Theory]
        [InlineData(10, 9)]
        [InlineData(1, 0)]
        [InlineData(0, -1)]
        [InlineData(-9, -10)]
        public void WhenQualityIsOne_AndOneDayPasses_TheSellInDecreasesByOne(
            int initial,
            int expected)
        {
            var items = new List<Item>
            {
                new Item
                {
                    Name = "Conjured Mana Cake",
                    SellIn = initial,
                    Quality = 1
                },
            };
            var sut = new GildedRose(items);

            sut.UpdateQuality();

            Assert.Equal(expected, items.First().SellIn);
        }

        [Theory]
        [InlineData(10, 8)]
        [InlineData(2, 0)]
        public void WhenOneDayPasses_TheQualityDecreasesByTwo(
            int initial,
            int expected)
        {
            var items = new List<Item>
            {
                new Item
                { 
                    Name = "Conjured Mana Cake",
                    SellIn = 1,
                    Quality = initial
                },
            };
            var sut = new GildedRose(items);

            sut.UpdateQuality();

            Assert.Equal(expected, items.First().Quality);
        }

        [Fact]
        public void WhenQualityIsOne_AndDayPasses_TheQualityIsZero()
        {
            var items = new List<Item>
            {
                new Item
                {
                    Name = "Conjured Mana Cake",
                    SellIn = 1,
                    Quality = 1
                },
            };
            var sut = new GildedRose(items);

            sut.UpdateQuality();

            Assert.Equal(0, items.First().Quality);
        }
    }
}
