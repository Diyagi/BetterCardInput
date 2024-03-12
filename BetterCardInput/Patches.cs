using HarmonyLib;

namespace BetterCardInput;

public class Patches
{
    [HarmonyPatch(typeof(PosTerminal), "Start")]
    public class PosTerminalStart()
    {
        [HarmonyPostfix]
        public static void Postfix(PosTerminal __instance)
        {
            if(__instance.GetComponent<CardInput>() == null)
            {
                BetterCardInputMod.Logger.Msg("Injecting component in PosTerminal...");
                __instance.gameObject.AddComponent<CardInput>();
            }
        }
    }
}