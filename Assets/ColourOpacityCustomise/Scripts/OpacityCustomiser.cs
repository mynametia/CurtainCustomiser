using UnityEngine;
using UnityEngine.UI;

public class OpacityCustomiser : MonoBehaviour
{
    public Renderer curtainRenderer;
    public Slider slider;

    public void UpdateCurtain(Renderer curtain)
    {
        curtainRenderer = curtain;
        slider.value = 1;
    }

    public void SliderUpdateOpacity()
    {
        UpdateOpacity(1-slider.value);
    }

    public void UpdateOpacity(float opacityValue)
    {
        Color objColor = curtainRenderer.sharedMaterial.color;
        objColor.a = opacityValue;
        curtainRenderer.sharedMaterial.color = objColor;
    }
}
