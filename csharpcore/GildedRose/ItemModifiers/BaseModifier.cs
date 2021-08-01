namespace GildedRoseKata
{
    public class BaseModifier : Modifier
    {
        private readonly Item _item;

        public BaseModifier(Item item)
        {
            _item = item;
        }

        public override ItemChangeset CalculateChangeset() => new ItemChangeset
        {
            ChangeInQuality = _item.SellIn > 0 ? -1 : -2,
            ChangeInSellIn = -1,
        };
    }
}
