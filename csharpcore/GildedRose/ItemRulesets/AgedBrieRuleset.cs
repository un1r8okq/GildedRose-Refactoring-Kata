namespace GildedRoseKata
{
    public class AgedBrieRuleset : ItemRuleset
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
                updatedQuality += 1;
            }
            else
            {
                updatedQuality += 2;
            }

            if (updatedQuality > 50)
            {
                updatedQuality = 50;
            }

            return updatedQuality;
        }

        private int CalculateSellIn(Item item) => item.SellIn - 1;
    }
}
