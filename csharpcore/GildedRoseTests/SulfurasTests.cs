using GildedRoseKata;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GildedRoseTests
{
    public class SulfurasTests
    {
        [Theory]
        [InlineData(10)]
        [InlineData(1)]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-10)]
        public void WhenOneDayPasses_TheSellInValueDoesNotDecrease(int sellIn)
        {
            var items = new List<Item>
            {
                new Item {
                    Name = "Sulfuras, Hand of Ragnaros",
                    SellIn = sellIn,
                },
            };
            var sut = new GildedRose(items);

            sut.UpdateQuality();

            Assert.Equal(sellIn, items.First().SellIn);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(1)]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-10)]
        public void WhenTwoDaysPass_TheSellInValueDoesNotDecrease(int sellIn)
        {
            var items = new List<Item>
            {
                new Item {
                    Name = "Sulfuras, Hand of Ragnaros",
                    SellIn = sellIn,
                },
            };
            var sut = new GildedRose(items);

            sut.UpdateQuality();
            sut.UpdateQuality();

            Assert.Equal(sellIn, items.First().SellIn);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(1)]
        public void WhenSellInIsOne_AndOneDayPasses_QualityDoesNotDecrease(
            int quality)
        {
            var items = new List<Item>
            {
                new Item
                {
                    Name = "Sulfuras, Hand of Ragnaros",
                    Quality = quality,
                    SellIn = 1,
                },
            };
            var sut = new GildedRose(items);

            sut.UpdateQuality();

            Assert.Equal(quality, items.First().Quality);
        }
    }
}
