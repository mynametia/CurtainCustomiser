//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourToggleController : MonoBehaviour
{
    public GameObject backgroundImage;

    private string colourName;
    public void OnSelect()
    {
        transform.parent.gameObject.GetComponent<ColourSelectionController>().UpdateCurtainColour(colourName);
    }
    public void OnInitiation(string name, Color c, bool selected, ToggleGroup toggleGroup)
    {
        colourName = name;
        backgroundImage.GetComponent<Image>().color = c;
        GetComponent<Toggle>().isOn = selected;
        GetComponent<Toggle>().group = toggleGroup;
    }
}
