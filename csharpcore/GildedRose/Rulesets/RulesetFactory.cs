using System.Linq;

namespace GildedRoseKata
{
    public static class RulesetFactory
    {
        private static readonly IRuleset[] _rulesets = new IRuleset[]
        {
                new AgedBrieRuleset(),
                new BackstagePassesRuleset(),
                new SulfurasRuleset(),
                new BaseRuleset(),
        };

        public static IRuleset GetRuleset(Item item) =>
            _rulesets.First(ruleset => ruleset.AppliesTo(item));
    }
}
