namespace GildedRoseKata
{
    public class SulfurasModifier : IModifier
    {
        public bool AppliesToItem(Item item) =>
            item.Name == ItemName.Sulfuras;

        public ItemChangeset GetChangeset(Item item) =>
            new ItemChangeset
            {
                ChangeInQuality = 0,
                ChangeInSellIn = 0,
            };
    }
}
