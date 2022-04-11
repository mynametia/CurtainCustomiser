using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurtainController : MonoBehaviour
{
    public List<GameObject> curtain_list = new List<GameObject>();
    public GameObject currentCurtain;
    public GameObject buttonPrefab;
    public GameObject scrollButtons;
    public GameObject opacitySlider;
    public GameObject colorChanger;
    public GameObject rightMenu;
    public Transform curtainTransform;
    // Start is called before the first frame update

    void Start()
    { 
        CreateButtons();
        rightMenu.SetActive(false);
    }

    public void CreateButtons(){
        foreach (GameObject curtain in curtain_list) 
        {
            string curtainTag = curtain.tag;
            GameObject button_inst = Instantiate(buttonPrefab, scrollButtons.transform);
            button_inst.transform.GetChild(0).GetComponent<Text>().text = curtainTag;
            button_inst.tag = curtainTag;
        }
    }

    public void UpdateCurrentCurtain(string curtain_tag)
    {
        foreach (GameObject curtain in curtain_list)
        {
            if(curtain_tag == curtain.tag)
            {
                currentCurtain = InstantiateCurtain(curtain);
                break;
            }
        }
        rightMenu.SetActive(false);
        rightMenu.SetActive(true);
        colorChanger.GetComponent<ColourSelectionController>().UpdateColourPresets(currentCurtain);
        opacitySlider.GetComponent<OpacityCustomiser>().UpdateCurtain(currentCurtain.GetComponent<Renderer>());
    }

    public GameObject InstantiateCurtain(GameObject curtainPrefab)
    {
        foreach (Transform child in curtainTransform)
        {
            GameObject.Destroy(child.gameObject);
        }
        return Instantiate(curtainPrefab, curtainTransform);
    }
}
