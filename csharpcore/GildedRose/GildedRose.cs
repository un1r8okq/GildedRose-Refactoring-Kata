using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                var ruleset = RulesetFactory.GetRuleset(item);
                var changes = ruleset.GetChanges(item);

                if (item.Name.StartsWith("Conjured ") && changes.ChangeInQuality < 0)
                {
                    changes.ChangeInQuality *= 2;
                }

                UpdateItem(item, changes);
            }
        }

        private void UpdateItem(Item item, ItemChanges changes)
        {
            item.Quality += changes.ChangeInQuality;
            item.SellIn += changes.ChangeInSellIn;

            if (item.Quality > 50)
            {
                item.Quality = 50;
            }
            else if (item.Quality < 0)
            {
                item.Quality = 0;
            }
        }
    }
}
