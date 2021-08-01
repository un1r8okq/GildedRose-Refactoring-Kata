namespace GildedRoseKata
{
    public class SulfurasModifier : Modifier
    {
        private readonly Item _item;

        public SulfurasModifier(Item item)
        {
            _item = item;
        }

        public override ItemChangeset CalculateChangeset() => new ItemChangeset
        {
            ChangeInQuality = 0,
            ChangeInSellIn = 0,
        };
    }
}
