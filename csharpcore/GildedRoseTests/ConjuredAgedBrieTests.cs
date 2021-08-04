using GildedRoseKata;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GildedRoseTests
{
    public class ConjuredAgedBrieTests
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
                    Name = "Conjured Aged Brie",
                    Quality = initial,
                    SellIn = 1,
                },
            };
            var sut = new GildedRose(items);

            sut.UpdateQuality();

            Assert.Equal(expected, items.First().Quality);
        }
    }
}
