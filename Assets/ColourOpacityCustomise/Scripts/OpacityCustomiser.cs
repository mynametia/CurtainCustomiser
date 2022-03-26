using UnityEngine;

public class OpacityCustomiser : MonoBehaviour
{
    public Renderer curtainRenderer;

    public void UpdateOpacity(float opacityValue)
    {
        Color objColor = curtainRenderer.material.color;
        objColor.a = opacityValue;
        curtainRenderer.material.color = objColor;
    }
}
