using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class IsActiveGlobalVolume : MonoBehaviour
{
    [SerializeField] private Volume globalVolume;
    private ColorAdjustments colorAdjustments;

    private void OnEnable()
    {
        if (globalVolume.profile.TryGet(out ColorAdjustments _colorAdjustments))
        {
           colorAdjustments = _colorAdjustments;
        }

        ToggleColorAdjustments(false);
    }

    public void ToggleColorAdjustments(bool enable)
    {
        if (colorAdjustments != null)
        {
            colorAdjustments.active = enable;
        }
    }

    private void OnDisable()
    {
        ToggleColorAdjustments(true);
    }
}
