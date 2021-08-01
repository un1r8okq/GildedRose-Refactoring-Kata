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
            var quality = CalculateQuality(changeSet);
            var sellIn = _item.SellIn + changeSet.ChangeInSellIn;

            return new Item
            {
                Name = _item.Name,
                Quality = quality,
                SellIn = sellIn,
            };
        }

        private int CalculateQuality(ItemChangeset changeSet)
        {
            var quality = _item.Quality;

            if (changeSet.QualityOverride != null)
            {
                quality = changeSet.QualityOverride.Value;
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
    }
}
