using GildedRoseKata;
using Xunit;

namespace GildedRoseTests
{
    public class ItemRulesetFactoryTests
    {
        [Fact]
        public void WhenItemNameIsNull_TheFactoryReturnsNull()
        {
            string itemName = null;

            var result = ItemRulesetFactory.GetRuleset(itemName);

            Assert.Null(result);
        }
    }
}
