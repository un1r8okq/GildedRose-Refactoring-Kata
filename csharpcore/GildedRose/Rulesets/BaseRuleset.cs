namespace GildedRoseKata
{
    public class BaseRuleset : IRuleset
    {
        public bool AppliesTo(Item item) => true;

        public ItemChanges GetChanges(Item item) =>
            new ItemChanges
            {
                ChangeInQuality = item.SellIn > 0 ? -1 : -2,
                ChangeInSellIn = -1,
            };
    }
}
