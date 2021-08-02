namespace GildedRoseKata
{
    public class BaseModifier : IModifier
    {
        public bool AppliesToItem(Item item) => true;

        public ItemChangeset GetChangeset(Item item) =>
            new ItemChangeset
            {
                ChangeInQuality = item.SellIn > 0 ? -1 : -2,
                ChangeInSellIn = -1,
            };
    }
}
