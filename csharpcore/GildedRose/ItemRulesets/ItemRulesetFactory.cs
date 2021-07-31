namespace GildedRoseKata
{
    public static class ItemRulesetFactory
    {
        public static ItemRuleset GetRuleset(string itemName) =>
            itemName switch
            {
                ItemName.AgedBrie => new AgedBrieRuleset(),
                ItemName.BackstagePasses => new BackstagePassesRuleset(),
                ItemName.Sulfuras => new SulfurasRuleset(),
                _ => new BaseItemRuleset(),
            };
    }
}
