namespace GildedRoseKata
{
    public class SulfurasRuleset : IRuleset
    {
        public bool AppliesTo(Item item) =>
            item.Name.Contains("Sulfuras, Hand of Ragnaros");

        public ItemChanges GetChanges(Item item) => new ItemChanges();
    }
}
