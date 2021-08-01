namespace GildedRoseKata
{
    public class AgedBrieModifier : Modifier
    {
        private readonly Item _item;

        public AgedBrieModifier(Item item)
        {
            _item = item;
        }

        public override ItemChangeset CalculateChangeset() => new ItemChangeset
        {
            ChangeInQuality = _item.SellIn > 0 ? 1 : 2,
            ChangeInSellIn = -1,
        };
    }
}
