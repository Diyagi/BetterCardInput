using MelonLoader;

namespace BetterCardInput;
public class BetterCardInputMod : MelonMod
{
    internal static MelonLogger.Instance Logger;
        
    public override void OnEarlyInitializeMelon()
    {
        Logger = LoggerInstance;
    }
}
