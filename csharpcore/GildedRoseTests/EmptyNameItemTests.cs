using Xunit;
using System.Collections.Generic;
using GildedRoseKata;
using System.Linq;

namespace GildedRoseTests
{
    public class EmptyNameItemTests
    {
        [Theory]
        [InlineData(10, 9)]
        [InlineData(1, 0)]
        [InlineData(0, -1)]
        [InlineData(-1, -2)]
        [InlineData(-10, -11)]
        public void UpdateQuality_TwoItems_FirstItemSellInDecrements(
            int initialSellIn,
            int expectedSellIn)
        {
            var items = new List<Item>
            {
                new Item { SellIn = initialSellIn },
                new Item(),
            };
            var sut = new GildedRose(items);

            sut.UpdateQuality();

            Assert.Equal(expectedSellIn, items.First().SellIn);
        }

        [Theory]
        [InlineData(10, 9)]
        [InlineData(1, 0)]
        [InlineData(0, -1)]
        [InlineData(-1, -2)]
        [InlineData(-10, -11)]
        public void UpdateQuality_TwoItems_SecondItemSellInDecrements(
            int initialSellIn,
            int expectedSellIn)
        {
            var items = new List<Item>
            {
                new Item(),
                new Item { SellIn = initialSellIn },
            };
            var sut = new GildedRose(items);

            sut.UpdateQuality();

            Assert.Equal(expectedSellIn, items[1].SellIn);
        }

        [Theory]
        [InlineData(2, 1)]
        [InlineData(1, 0)]
        public void UpdateQuality_SellInIsOne_QualityDecrements(
            int initialQuality,
            int expectedQuality)
        {
            var items = new List<Item>
            {
                new Item
                {
                    SellIn = 1,
                    Quality = initialQuality,
                },
            };
            var sut = new GildedRose(items);

            sut.UpdateQuality();

            Assert.Equal(expectedQuality, items.First().Quality);
        }

        [Theory]
        [InlineData(0, 2, 0)]
        [InlineData(-1, 2, 0)]
        public void UpdateQuality_SellInLessThanOne_QualityDecreasesByTwo(
            int initialSellIn,
            int initialQuality,
            int expectedQuality)
        {
            var items = new List<Item>
            {
                new Item
                {
                    SellIn = initialSellIn,
                    Quality = initialQuality,
                },
            };
            var sut = new GildedRose(items);

            sut.UpdateQuality();

            Assert.Equal(expectedQuality, items.First().Quality);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(0)]
        [InlineData(-1)]
        public void UpdateQuality_QualityIsZero_QualityDoesNotChange(int sellIn)
        {
            var items = new List<Item>
            {
                new Item
                {
                    SellIn = sellIn,
                    Quality = 0,
                },
            };
            var sut = new GildedRose(items);

            sut.UpdateQuality();

            Assert.Equal(0, items.First().Quality);
        }
    }
}
