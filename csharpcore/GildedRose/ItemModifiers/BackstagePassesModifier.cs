namespace GildedRoseKata
{
    public class BackstagePassesModifier : IModifier
    {
        public bool AppliesToItem(Item item) =>
            item.Name == ItemName.BackstagePasses;

        public ItemChangeset GetChangeset(Item item)
        {
            var changeset = new ItemChangeset
            {
                ChangeInSellIn = -1,
            };

            if (item.SellIn <= 0)
            {
                changeset.OverrideQuality = 0;
            }
            else
            {
                changeset.ChangeInQuality = CalculateChangeInQuality(item);
            }

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
            return 0;
        }
    }
}
