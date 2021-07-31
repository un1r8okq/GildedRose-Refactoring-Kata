using System;

namespace GildedRoseKata
{
    public class BackstagePassesRuleset : ItemRuleset
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

            if (item.SellIn > 10)
            {
                updatedQuality += 1;
            }
            else if (item.SellIn <= 10 && item.SellIn > 5)
            {
                updatedQuality += 2;
            }
            else if (item.SellIn <= 5 && item.SellIn > 0)
            {
                updatedQuality += 3;
            }
            else
            {
                updatedQuality = 0;
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
