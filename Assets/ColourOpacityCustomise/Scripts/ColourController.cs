using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourController : MonoBehaviour
{
    // List of colour presets a curtain prefab has
    public List<ColourPreset> colourPresets = new List<ColourPreset>();

    public ColourPreset currentColour;
    // Start is called before the first frame update
    void Start()
    {
        currentColour = colourPresets[0];
        GetComponent<Renderer>().material.SetTexture("_MainTex", currentColour.texture);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Updates albedo texture of the material
    public void UpdateColour(string colourName)
    {
        foreach (ColourPreset c in colourPresets)
        {
            if (c.colourName == colourName)
            {
                currentColour = c;
                break;
            }
        }
        GetComponent<Renderer>().material.SetTexture("_MainTex", currentColour.texture);
    }
}
