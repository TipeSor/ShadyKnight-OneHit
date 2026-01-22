using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace OneHit
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.NAME, PluginInfo.VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        internal static new ManualLogSource Logger;

        public void Awake()
        {
            Logger = base.Logger;
            Logger.LogInfo($"Plugin {PluginInfo.GUID} is loaded!");

            Harmony harmony = new(PluginInfo.GUID);

            PlayerController.OnDamage += static (_) => Game.instance.Restart();

            harmony.PatchAll();
        }
    }
}
