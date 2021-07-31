using Xunit;
using System.Collections.Generic;
using GildedRoseKata;
using System.Linq;
using System.Diagnostics;

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
        public void WhenOneDayPasses_TheSellInValueDecreasesByOne(
            int initial,
            int expected)
        {
            var items = new List<Item>
            {
                new Item { SellIn = initial },
            };
            var sut = new GildedRose(items);

            sut.UpdateQuality();

            Assert.Equal(expected, items.First().SellIn);
        }

        [Theory]
        [InlineData(10, 8)]
        [InlineData(3, 1)]
        [InlineData(2, 0)]
        [InlineData(1, -1)]
        [InlineData(-1, -3)]
        [InlineData(-10, -12)]
        public void WhenTwoDaysPass_TheSellInValueDecreasesByTwo(
            int initial,
            int expected)
        {
            var items = new List<Item>
            {
                new Item { SellIn = initial },
            };
            var sut = new GildedRose(items);

            sut.UpdateQuality();
            sut.UpdateQuality();

            Assert.Equal(expected, items.First().SellIn);
        }

        [Theory]
        [InlineData(10, 9)]
        [InlineData(1, 0)]
        public void WhenSellInIsOne_AndOneDayPasses_QualityDecreasesByOne(
            int initial,
            int expected)
        {
            var items = new List<Item>
            {
                new Item
                {
                    SellIn = 1,
                    Quality = initial,
                },
            };
            var sut = new GildedRose(items);

            sut.UpdateQuality();

            Assert.Equal(expected, items.First().Quality);
        }

        [Theory]
        [InlineData(10, 8)]
        [InlineData(3, 1)]
        [InlineData(2, 0)]
        public void WhenSellInIsZero_AndOneDayPasses_QualityDecreasesByTwo(
            int initial,
            int expected)
        {
            var items = new List<Item>
            {
                new Item
                {
                    SellIn = 0,
                    Quality = initial,
                },
            };
            var sut = new GildedRose(items);

            sut.UpdateQuality();

            Assert.Equal(expected, items.First().Quality);
        }

        [Theory]
        [InlineData(10, 8)]
        [InlineData(3, 1)]
        [InlineData(2, 0)]
        public void WhenSellInIsNegativeOne_AndOneDayPasses_QualityDecreasesByTwo(
            int initial,
            int expected)
        {
            var items = new List<Item>
            {
                new Item
                {
                    SellIn = -1,
                    Quality = initial,
                },
            };
            var sut = new GildedRose(items);

            sut.UpdateQuality();

            Assert.Equal(expected, items.First().Quality);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(1)]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-10)]
        public void WhenQualityIsZero_AndOneDayPasses_QualityRemainsZero(
            int sellIn)
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

        [Theory]
        [InlineData(10, 9)]
        [InlineData(1, 0)]
        [InlineData(0, -1)]
        [InlineData(-1, -2)]
        [InlineData(-10, -11)]
        public void WhenThereAreThreeItems_AndOneDayPasses_TheSellInValueDecreasesByOneForEachItem(
            int initial,
            int expected)
        {
            var items = new List<Item>
            {
                new Item { SellIn = initial },
                new Item { SellIn = initial },
                new Item { SellIn = initial },
            };
            var sut = new GildedRose(items);

            sut.UpdateQuality();

            Assert.Equal(expected, items[0].SellIn);
            Assert.Equal(expected, items[1].SellIn);
            Assert.Equal(expected, items[2].SellIn);
        }

        [Theory]
        [InlineData(10, 9)]
        [InlineData(1, 0)]
        public void WhenThereAreThreeItems_AndTheirSellInIsOne_AndOneDayPasses_TheQualityDecreasesByOneForEachItem(
            int initial,
            int expected)
        {
            var items = new List<Item>
            {
                new Item
                {
                    SellIn = 1,
                    Quality = initial,
                },
                new Item
                {
                    SellIn = 1,
                    Quality = initial,
                },
                new Item
                {
                    SellIn = 1,
                    Quality = initial,
                },
            };
            var sut = new GildedRose(items);

            sut.UpdateQuality();

            Assert.Equal(expected, items[0].Quality);
            Assert.Equal(expected, items[1].Quality);
            Assert.Equal(expected, items[2].Quality);
        }

        [Fact]
        public void When100000DaysPass_ItTakesLessThan200Ms()
        {
            var items = new List<Item>();
            for (var i = 0; i < 100000; i++) items.Add(new Item());
            var sut = new GildedRose(items);
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            sut.UpdateQuality();
            stopwatch.Stop();

            Assert.InRange(stopwatch.ElapsedMilliseconds, 0, 200);
        }
    }
}
