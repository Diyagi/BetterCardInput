using HarmonyLib;
using UnityEngine;

namespace BetterCardInput;

public class CardInput : MonoBehaviour
{
    private PosTerminal _posTerminal;
    private GameObject _mPosCam;

    private void Start()
    {
        BetterCardInputMod.Logger.Msg("Component injected!");
        _posTerminal = GetComponentInParent<PosTerminal>();
        _mPosCam = (GameObject)AccessTools.DeclaredField(typeof(PosTerminal), "m_PosCam").GetValue(_posTerminal)!;
    }
    
    private void Update()
    {
        if (!_mPosCam.activeSelf) return;
        
        foreach (char c in Input.inputString)
        {
            switch (c)
            {
                case '\b':
                    _posTerminal.RemoveCharacter();
                    break;
                
                case '\n':
                case '\r':
                    _posTerminal.Approve();
                    break;
                
                case ',':
                case '.':
                    _posTerminal.AddChar(".");
                    break;
                
                default:
                {
                    if (char.IsNumber(c))
                    {
                        _posTerminal.AddChar(c.ToString());
                    }

                    break;
                }
            }
        }
    }
}