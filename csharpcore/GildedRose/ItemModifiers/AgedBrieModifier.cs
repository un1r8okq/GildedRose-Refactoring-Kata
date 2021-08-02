namespace GildedRoseKata
{
    public class AgedBrieModifier : Modifier <= Interface
    {
        private readonly Item _item;

        public AgedBrieModifier(Item item) <= Modifier
        {
            _item = item;
        }

        public bool ShouldRun()?

        public override ItemChangeset CalculateChangeset() => new ItemChangeset
        {
            ChangeInQuality = _item.SellIn > 0 ? 1 : 2,
            ChangeInSellIn = -1,
        };
    }
}
