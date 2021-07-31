using Xunit;
using GildedRoseKata;
using System.Diagnostics;

namespace GildedRoseTests
{
    public class BaseItemRulesetTests
    {
        [Theory]
        [InlineData(10, 9)]
        [InlineData(1, 0)]
        [InlineData(0, -1)]
        [InlineData(-1, -2)]
        [InlineData(-10, -11)]
        public void WhenTheItemIsUpdated_TheSellInValueDecreasesByOne(
            int initial,
            int expected)
        {
            var item = new Item { SellIn = initial };
            var sut = new BaseItemRuleset();

            var updatedItem = sut.UpdateItem(item);

            Assert.Equal(expected, updatedItem.SellIn);
        }

        [Theory]
        [InlineData(10, 9)]
        [InlineData(1, 0)]
        public void WhenSellInIsOne_AndTheItemIsUpdated_QualityDecreasesByOne(
            int initial,
            int expected)
        {
            var item = new Item { Quality = initial, SellIn = 1 };
            var sut = new BaseItemRuleset();

            var updatedItem = sut.UpdateItem(item);

            Assert.Equal(expected, updatedItem.Quality);
        }

        [Theory]
        [InlineData(10, 8)]
        [InlineData(3, 1)]
        [InlineData(2, 0)]
        public void WhenSellInIsZero_AndTheItemIsUpdated_QualityDecreasesByTwo(
            int initial,
            int expected)
        {
            var item = new Item { Quality = initial, SellIn = 0 };
            var sut = new BaseItemRuleset();

            var updatedItem = sut.UpdateItem(item);

            Assert.Equal(expected, updatedItem.Quality);
        }

        [Theory]
        [InlineData(10, 8)]
        [InlineData(3, 1)]
        [InlineData(2, 0)]
        public void WhenSellInIsNegativeOne_AndTheItemIsUpdated_QualityDecreasesByTwo(
            int initial,
            int expected)
        {
            var item = new Item { Quality = initial, SellIn = -1 };
            var sut = new BaseItemRuleset();

            var updatedItem = sut.UpdateItem(item);

            Assert.Equal(expected, updatedItem.Quality);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(1)]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-10)]
        public void WhenQualityIsZero_AndTheItemIsUpdated_QualityRemainsZero(
            int sellIn)
        {
            var item = new Item { Quality = 0, SellIn = sellIn };
            var sut = new BaseItemRuleset();

            var updatedItem = sut.UpdateItem(item);

            Assert.Equal(0, updatedItem.Quality);
        }

        [Fact]
        public void WhenItemIsUpdated_NewObjectIsReturned()
        {
            var item = new Item();
            var sut = new BaseItemRuleset();

            var newItem = sut.UpdateItem(item);

            Assert.NotSame(item, newItem);
        }

        [Fact]
        public void When100000ItemsAreUpdated_ItTakesLessThan200Ms()
        {
            var stopwatch = new Stopwatch();
            var sut = new BaseItemRuleset();

            stopwatch.Start();
            for (var i = 0; i < 100000; i++)
            {
                sut.UpdateItem(new Item());
            }
            stopwatch.Stop();

            Assert.InRange(stopwatch.ElapsedMilliseconds, 0, 200);
        }
    }
}
