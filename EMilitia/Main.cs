using System.Reflection;
using HarmonyLib;
using TaleWorlds.MountAndBlade;

namespace EMilitia
{
    public class Main : MBSubModuleBase
    {
        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            base.OnBeforeInitialModuleScreenSetAsRoot();
            var harmony = new Harmony("EMilitia.harmony");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}