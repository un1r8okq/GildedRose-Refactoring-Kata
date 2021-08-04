namespace GildedRoseKata
{
    public class BackstagePassesModifier : IRuleset
    {
        public bool AppliesTo(Item item) =>
            item.Name == ItemName.BackstagePasses;

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
