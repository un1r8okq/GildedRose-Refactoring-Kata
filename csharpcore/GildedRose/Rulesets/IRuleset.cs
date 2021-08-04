namespace GildedRoseKata
{
    public interface IRuleset
    {
        public bool AppliesTo(Item item);

        public ItemChanges GetChanges(Item item);
    }
}
