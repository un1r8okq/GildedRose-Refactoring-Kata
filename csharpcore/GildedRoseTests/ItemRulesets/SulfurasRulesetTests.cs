using GildedRoseKata;
using System.Diagnostics;
using Xunit;

namespace GildedRoseTests
{
    public class SulfurasRulesetTests
    {
        [Theory]
        [InlineData(10)]
        [InlineData(1)]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-10)]
        public void WhenItemIsUpdated_TheSellInValueDoesNotDecrease(int sellIn)
        {
            var item = new Item {
                Name = "Sulfuras, Hand of Ragnaros",
                SellIn = sellIn,
            };
            var sut = new SulfurasRuleset();

            var newItem = sut.UpdateItem(item);

            Assert.Equal(sellIn, newItem.SellIn);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(1)]
        public void WhenSellInIsOne_AndItemIsUpdated_QualityDoesNotDecrease(
            int quality)
        {
            var item = new Item
            {
                Name = "Sulfuras, Hand of Ragnaros",
                Quality = quality,
                SellIn = 1,
            };
            var sut = new SulfurasRuleset();

            var newItem = sut.UpdateItem(item);

            Assert.Equal(quality, item.Quality);
        }

        [Fact]
        public void WhenItemIsUpdated_NewObjectIsReturned()
        {
            var item = new Item { Name = "Sulfuras, Hand of Ragnaros" };
            var sut = new SulfurasRuleset();

            var newItem = sut.UpdateItem(item);

            Assert.NotSame(item, newItem);
        }

        [Fact]
        public void When100000ItemsAreUpdated_ItTakesLessThan200Ms()
        {
            var stopwatch = new Stopwatch();
            var item = new Item { Name = "Sulfuras, Hand of Ragnaros" };
            var sut = new SulfurasRuleset();

            stopwatch.Start();
            for (var i = 0; i < 100000; i++)
            {
                sut.UpdateItem(item);
            }
            stopwatch.Stop();

            Assert.InRange(stopwatch.ElapsedMilliseconds, 0, 200);
        }
    }
}
