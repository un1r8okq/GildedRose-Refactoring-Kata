namespace GildedRoseKata
{
    public abstract class Modifier
    {
        protected Modifier _modifier;

        public abstract ItemChangeset CalculateChangeset();
    }
}
