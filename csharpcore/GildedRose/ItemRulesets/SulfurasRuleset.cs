namespace GildedRoseKata
{
    public class SulfurasRuleset : ItemRuleset
    {
        public Item UpdateItem(Item item) =>
            new Item
            {
                Name = item.Name,
                Quality = item.Quality,
                SellIn = item.SellIn,
            };
    }
}
