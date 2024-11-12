using NUnit.Framework.Constraints;
using UnityEngine;

public class DebugPowerMenu : MonoBehaviour
{
    public void SetAction(int effect_idx)
    {
        switch (effect_idx)
        {
            default:
            case 0:
                ClickEffect.SetClickMode(ClickEffect.ClickEffectType.NormalClick);
                break;
            case 1:
                ClickEffect.SetClickMode(ClickEffect.ClickEffectType.Eraser);
                break;
        }
    }
}
