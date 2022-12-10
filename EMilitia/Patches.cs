using HarmonyLib;
using MCM.Abstractions.Base.Global;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Library;

namespace EMilitia
{
    [HarmonyPatch(typeof(DefaultSettlementMilitiaModel))]
    public class Patches
    {
        private static readonly Settings settings = GlobalSettings<Settings>.Instance;

        [HarmonyPostfix]
        [HarmonyPatch("CalculateEliteMilitiaSpawnChance")]
        public static void CalculateEliteMilitiaSpawnChancePostfix(
            ref float __result,
            Settlement settlement)
        {
            Hero hero = null;

            if (settlement.IsFortification && settlement.Town.Governor != null)
            {
                hero = settlement.Town.Governor;
            }
            else if (settlement.IsVillage && settlement.Village.TradeBound?.Town.Governor != null)
            {
                hero = settlement.Village.TradeBound.Town.Governor;
            }

            // Perk bonus is already applied in base method so applying only extra % bonus
            if (hero != null) 
            {
                if (settings.PlayerOwnedSettlementsOnly && hero.Clan.Kingdom != Hero.MainHero.Clan.Kingdom)
                {
                    return;
                }

                if (settlement.IsTown)
                {
                    __result += settings.TownEliteMilitiaSpawnRateBonus;
                }
                else if (settlement.IsCastle)
                {
                    __result += settings.CastleEliteMilitiaSpawnRateBonus;
                }
                else if (settlement.IsVillage)
                {
                    __result += settings.VillageEliteMilitiaSpawnRateBonus;
                }
            }
        }
    }
}