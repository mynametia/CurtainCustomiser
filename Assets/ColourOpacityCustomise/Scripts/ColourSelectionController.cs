//using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourSelectionController : MonoBehaviour
{
    public GameObject togglePrefab, currentCurtain;

    private List<ColourPreset> colourPresets;

    // Start is called before the first frame update
    void Start()
    {
        //UpdateColourPresets(currentCurtain);
    }

    // Called when new colour is selected
    public void UpdateCurtainColour(string colourName)
    {
        currentCurtain.GetComponent<ColourController>().UpdateColour(colourName);
    }

    // Called when new curtain type is selected
    public void UpdateColourPresets(GameObject curtainObject)
    {
        currentCurtain = curtainObject;
        
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        colourPresets = curtainObject.GetComponent<ColourController>().colourPresets;

        GameObject t;
        bool selected = true;
        foreach (ColourPreset c in colourPresets)
        {
            t = Instantiate(togglePrefab, transform);
            t.GetComponent<ColourToggleController>().OnInitiation(c.colourName, c.previewColour, selected, GetComponent<ToggleGroup>());
            selected = false;
        }

    }
}
