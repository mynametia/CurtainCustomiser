using UnityEngine;

[System.Serializable]
public class ColourPreset
{
    public string colourName;
    public Texture texture;
    public Color previewColour;

    public ColourPreset(string name, Texture txt, Color colour)
    {
        colourName = name;
        texture = txt;
        previewColour = colour;
    }
}
