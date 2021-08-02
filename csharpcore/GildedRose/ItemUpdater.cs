using System;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public class ItemUpdater
    {
        private readonly List<IModifier> _modifiers;
        private readonly Item _item;

        public ItemUpdater(Item item)
        {
            _modifiers = new List<IModifier>
            {
                new AgedBrieModifier(),
                new BackstagePassesModifier(),
                new SulfurasModifier(),
                new BaseModifier(),
            };
            _item = item;
        }

        public void UpdateItem()
        {
            var changeSet = GetChangeset();
            _item.Quality = GetQuality(changeSet);
            _item.SellIn = GetSellIn(changeSet);
        }

        private ItemChangeset GetChangeset()
        {
            var modifier = _modifiers.Find(m => m.AppliesToItem(_item));

            if (modifier == null)
            {
                throw new Exception("No matching modifier");
            }

            return modifier.GetChangeset(_item);
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
