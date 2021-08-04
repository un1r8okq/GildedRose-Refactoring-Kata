namespace GildedRoseKata
{
    public class AgedBrieRuleset : IRuleset
    {
        public bool AppliesTo(Item item) =>
            item.Name.Contains("Aged Brie");

        public ItemChanges GetChanges(Item item) =>
            new ItemChanges
            {

                ChangeInQuality = item.SellIn > 0 ? 1 : 2,
                ChangeInSellIn = -1,
            };
    }
}
