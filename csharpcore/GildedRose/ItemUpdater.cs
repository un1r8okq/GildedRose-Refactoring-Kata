namespace GildedRoseKata
{
    public class ItemUpdater
    {
        private readonly Item _item;

        public ItemUpdater(Item item)
        {
            _item = item;
        }

        public Item UpdateItem()
        {
            var changeSet = GetChangeset();
            var quality = GetQuality(changeSet);
            var sellIn = GetSellIn(changeSet);

            return new Item
            {
                Name = _item.Name,
                Quality = quality,
                SellIn = sellIn,
            };
        }

        private ItemChangeset GetChangeset()
        {
            Modifier modifier;

            if (_item.Name == ItemName.AgedBrie)
            {
                modifier = new AgedBrieModifier(_item);
            }
            else if (_item.Name == ItemName.BackstagePasses)
            {
                modifier = new BackstagePassesModifier(_item);
            }
            else if (_item.Name == ItemName.Sulfuras)
            {
                modifier = new SulfurasModifier(_item);
            }
            else
            {
                modifier = new BaseModifier(_item);
            }

            return modifier.CalculateChangeset();
        }

        private int GetQuality(ItemChangeset changeSet)
        {
            var quality = _item.Quality;

            if (changeSet.OverrideQuality != null)
            {
                quality = changeSet.OverrideQuality.Value;
            }
            else
            {
                quality += changeSet.ChangeInQuality;
            }

            if (quality < 0)
            {
                quality = 0;
            }
            else if (quality > 50)
            {
                quality = 50;
            }

            return quality;
        }

        private int GetSellIn(ItemChangeset changeSet) =>
            _item.SellIn + changeSet.ChangeInSellIn;
    }
}
