namespace GildedRoseKata
{
    public class BackstagePassesRuleset : IRuleset
    {
        public bool AppliesTo(Item item) =>
            item.Name.Contains("Backstage passes to a TAFKAL80ETC concert");

        public ItemChanges GetChanges(Item item)
        {
            var changeset = new ItemChanges
            {
                ChangeInSellIn = -1,
            };

            changeset.ChangeInQuality = CalculateChangeInQuality(item);

            return changeset;
        }

        private int CalculateChangeInQuality(Item item)
        {
            if (item.SellIn > 10)
            {
                return 1;
            }
            else if (item.SellIn <= 10 && item.SellIn > 5)
            {
                return 2;
            }
            else if (item.SellIn <= 5 && item.SellIn > 0)
            {
                return 3;
            }
            return -item.Quality;
        }
    }
}
