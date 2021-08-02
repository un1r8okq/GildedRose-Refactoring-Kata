namespace GildedRoseKata
{
    public interface IModifier
    {
        public bool AppliesToItem(Item item);

        public ItemChangeset GetChangeset(Item item);
    }
}
