﻿using System.Collections.Generic;

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
            for (var i = 0; i < Items.Count; i++)
            {
                var ruleset = ItemRulesetFactory.GetRuleset(Items[i].Name);
                Items[i] = ruleset.UpdateItem(Items[i]);
            }
        }
    }
}
