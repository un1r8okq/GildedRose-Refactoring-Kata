namespace GildedRoseKata
{
    public class SulfurasModifier : IRuleset
    {
        public bool AppliesTo(Item item) =>
            item.Name == ItemName.Sulfuras;

        public ItemChanges GetChanges(Item item) =>
            new ItemChanges
            {
                ChangeInQuality = 0,
                ChangeInSellIn = 0,
            };
    }
}
