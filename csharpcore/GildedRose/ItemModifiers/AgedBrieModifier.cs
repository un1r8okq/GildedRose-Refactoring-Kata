namespace GildedRoseKata
{
    public class AgedBrieModifier : IRuleset
    {
        public bool AppliesTo(Item item) =>
            item.Name == ItemName.AgedBrie;

        public ItemChanges GetChanges(Item item) =>
            new ItemChanges
            {

                ChangeInQuality = item.SellIn > 0 ? 1 : 2,
                ChangeInSellIn = -1,
            };
    }
}
