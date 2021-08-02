namespace GildedRoseKata
{
    public class AgedBrieModifier : IModifier
    {
        public bool AppliesToItem(Item item) =>
            item.Name == ItemName.AgedBrie;

        public ItemChangeset GetChangeset(Item item) =>
            new ItemChangeset
            {

                ChangeInQuality = item.SellIn > 0 ? 1 : 2,
                ChangeInSellIn = -1,
            };
    }
}
