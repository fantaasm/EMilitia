using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Base.Global;

namespace EMilitia
{
    public class Settings : AttributeGlobalSettings<Settings>
    {
        [SettingPropertyGroup("Militia")]
        [SettingPropertyFloatingInteger("Town Elite Militia Spawn Chance", 0.00f, 1f, "0%",
                                        HintText = "An extra elite militia spawn chance for towns added on top of other calculations (skills etc..)",
                                        Order = 1,
                                        RequireRestart = false)]
        public float TownEliteMilitiaSpawnRateBonus { get; set; } = 0.0f;

        [SettingPropertyGroup("Militia")]
        [SettingPropertyFloatingInteger("Castle Elite Militia Spawn Chance", 0.00f, 1f, "0%",
                                        HintText = "An extra elite militia spawn chance for castles added on top of other calculations (skills etc..)",
                                        Order = 2,
                                        RequireRestart = false)]
        public float CastleEliteMilitiaSpawnRateBonus { get; set; } = 0.0f;

        [SettingPropertyGroup("Militia")]
        [SettingPropertyFloatingInteger("Village Elite Militia Spawn Chance", 0.00f, 1f, "0%",
                                        HintText = "An extra elite militia spawn chance for villages added on top of other calculations (skills etc..)",
                                        Order = 3,
                                        RequireRestart = false)]
        public float VillageEliteMilitiaSpawnRateBonus { get; set; } = 0.0f;

        [SettingPropertyGroup("Militia")]
        [SettingPropertyBool("Player owned settlements only", HintText = "If enabled, only player owned settlements will get the bonus chance",
                             Order = 4,
                             RequireRestart = false)]
        public bool PlayerOwnedSettlementsOnly { get; set; } = false;

        public override string Id => "E-Militia";
        public override string DisplayName => "E-Militia v1.1.0";
        public override string FolderName => "EMilitia";
        public override string FormatType => "json";
        
    }
}