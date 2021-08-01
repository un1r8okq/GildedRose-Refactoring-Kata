namespace GildedRoseKata
{
    public class BackstagePassesModifier : Modifier
    {
        private readonly Item _item;

        public BackstagePassesModifier(Item item)
        {
            _item = item;
        }

        public override ItemChangeset CalculateChangeset()
        {
            var changeset = new ItemChangeset
            {
                ChangeInSellIn = -1,
            };

            if (_item.SellIn <= 0)
            {
                changeset.QualityOverride = 0;
            }
            else
            {
                changeset.ChangeInQuality = CalculateChangeInQuality();
            }

            return changeset;
        }

        private int CalculateChangeInQuality()
        {
            if (_item.SellIn > 10)
            {
                return 1;
            }
            else if (_item.SellIn <= 10 && _item.SellIn > 5)
            {
                return 2;
            }
            else if (_item.SellIn <= 5 && _item.SellIn > 0)
            {
                return 3;
            }
            return 0;
        }
    }
}
