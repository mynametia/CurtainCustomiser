using UnityEngine;
using UnityEngine.UI;

public class OpacityCustomiser : MonoBehaviour
{
    public Renderer curtainRenderer;
    public Slider slider;

    public void SliderUpdateOpacity()
    {
        UpdateOpacity(1-slider.value);
    }

    public void UpdateOpacity(float opacityValue)
    {
        Color objColor = curtainRenderer.material.color;
        objColor.a = opacityValue;
        curtainRenderer.material.color = objColor;
    }
}
