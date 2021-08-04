using System.Linq;

namespace GildedRoseKata
{
    public static class RulesetFactory
    {
        private static readonly IRuleset[] _rulesets = new IRuleset[]
        {
                new AgedBrieModifier(),
                new BackstagePassesModifier(),
                new BaseModifier(),
        };

        public static IRuleset GetRuleset(Item item) =>
            _rulesets.First(ruleset => ruleset.AppliesTo(item));
    }
}
