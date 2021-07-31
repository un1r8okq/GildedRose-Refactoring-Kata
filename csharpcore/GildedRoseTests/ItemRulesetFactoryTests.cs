using GildedRoseKata;
using Xunit;

namespace GildedRoseTests
{
    public class ItemRulesetFactoryTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("🤠")]
        [InlineData("咕咾肉")]
        [InlineData("An item")]
        [InlineData("AGED BRIE")]
        [InlineData("aged brie")]
        [InlineData(" Aged Brie")]
        [InlineData("Aged Brie ")]
        [InlineData("Aged Brie with a cowboy hat on it")]
        public void GivenAnItemNameThatIsNotASpecialCase_TheFactoryReturnsTheBaseItemRuleset(
            string itemName)
        {
            var ruleset = ItemRulesetFactory.GetRuleset(itemName);

            Assert.IsType<BaseItemRuleset>(ruleset);
        }

        [Fact]
        public void WhenItemNameIsAgedBrie_TheFactoryReturnsTheAgedBrieRuleset()
        {
            var itemName = "Aged Brie";
            var ruleset = ItemRulesetFactory.GetRuleset(itemName);

            Assert.IsType<AgedBrieRuleset>(ruleset);
        }

        [Fact]
        public void WhenItemNameIsBackstagePasses_TheFactoryReturnsTheBackstagePassesRuleset()
        {
            var itemName = "Backstage passes to a TAFKAL80ETC concert";
            var ruleset = ItemRulesetFactory.GetRuleset(itemName);

            Assert.IsType<BackstagePassesRuleset>(ruleset);
        }

        [Fact]
        public void WhenItemNameIsSulfuras_TheFactoryReturnsTheSulfurasRuleset()
        {
            var itemName = "Sulfuras, Hand of Ragnaros";
            var ruleset = ItemRulesetFactory.GetRuleset(itemName);

            Assert.IsType<SulfurasRuleset>(ruleset);
        }
    }
}
