using GildedRoseKata;
using System.Diagnostics;
using Xunit;

namespace GildedRoseTests
{
    public class AgedBrieRulesetTests
    {
        [Theory]
        [InlineData(10, 11)]
        [InlineData(0, 1)]
        public void WhenSellInIsOne_AndItemIsUpdated_QualityIncreasesByOne(
            int initial,
            int expected)
        {
            var item = new Item
                {
                    Name = "Aged Brie",
                    Quality = initial,
                    SellIn = 1,
                };
            var sut = new AgedBrieRuleset();

            var newItem = sut.UpdateItem(item);

            Assert.Equal(expected, newItem.Quality);
        }

        [Theory]
        [InlineData(10, 12)]
        [InlineData(0, 2)]
        public void WhenSellInIsZero_AndItemIsUpdated_QualityIncreasesByTwo(
            int initial,
            int expected)
        {
            var item = new Item
            {
                Name = "Aged Brie",
                Quality = initial,
                SellIn = 0,
            };
            var sut = new AgedBrieRuleset();

            var newItem = sut.UpdateItem(item);

            Assert.Equal(expected, newItem.Quality);
        }

        [Theory]
        [InlineData(10, 12)]
        [InlineData(0, 2)]
        public void WhenSellInIsNegativeOne_AndItemIsUpdated_QualityIncreasesByTwo(
            int initial,
            int expected)
        {
            var item = new Item
            {
                Name = "Aged Brie",
                Quality = initial,
                SellIn = -1,
            };
            var sut = new AgedBrieRuleset();

            var newItem = sut.UpdateItem(item);

            Assert.Equal(expected, newItem.Quality);
        }

        [Fact]
        public void WhenSellInIsOne_AndQualityIsFifty_AndItemIsUpdated_QualityDoesNotChange()
        {
            var item = new Item
            {
                Name = "Aged Brie",
                Quality = 50,
                SellIn = 1,
            };
            var sut = new AgedBrieRuleset();

            var newItem = sut.UpdateItem(item);

            Assert.Equal(50, newItem.Quality);
        }

        [Fact]
        public void WhenSellInIsZero_AndQualityIsFifty_AndItemIsUpdated_QualityDoesNotChange()
        {
            var item = new Item
            {
                Name = "Aged Brie",
                Quality = 50,
                SellIn = 0,
            };
            var sut = new AgedBrieRuleset();

            var newItem = sut.UpdateItem(item);

            Assert.Equal(50, newItem.Quality);
        }

        [Fact]
        public void WhenItemIsUpdated_NewObjectIsReturned()
        {
            var item = new Item();
            var sut = new AgedBrieRuleset();

            var newItem = sut.UpdateItem(new Item { Name = "Aged Brie" });

            Assert.NotSame(item, newItem);
        }

        [Fact]
        public void When100000ItemsAreUpdated_ItTakesLessThan200Ms()
        {
            var sut = new AgedBrieRuleset();
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            for (var i = 0; i < 100000; i++)
            {
                sut.UpdateItem(new Item { Name = "Aged Brie" });
            }
            stopwatch.Stop();

            Assert.InRange(stopwatch.ElapsedMilliseconds, 0, 200);
        }
    }
}
