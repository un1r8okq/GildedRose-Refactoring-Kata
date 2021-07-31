namespace GildedRoseKata
{
    public class BaseItemRuleset : ItemRuleset
    {
        public Item UpdateItem(Item item) =>
            new Item
            {
                Name = item.Name,
                Quality = CalculateQuality(item),
                SellIn = CalculateSellIn(item),
            };

        private int CalculateQuality(Item item)
        {
            var updatedQuality = item.Quality;

            if (item.SellIn > 0)
            {
                updatedQuality -= 1;
            }
            else
            {
                updatedQuality -= 2;
            }

            if (updatedQuality < 0)
            {
                updatedQuality = 0;
            }

            return updatedQuality;
        }

        private int CalculateSellIn(Item item) => item.SellIn - 1;
    }
}
