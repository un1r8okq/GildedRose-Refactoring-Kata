namespace GildedRoseKata
{
    public class BaseItemRuleset : ItemRuleset
    {
        public Item UpdateItem(Item item)
        {
            var quality = CalculateNewQuality(item);
            var sellIn = item.SellIn - 1;

            return new Item
            {
                Name = item.Name,
                Quality = quality,
                SellIn = sellIn,
            };
        }

        private int CalculateNewQuality(Item item)
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
    }
}
