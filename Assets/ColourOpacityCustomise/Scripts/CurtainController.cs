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
    public GameObject rightMenu, leftMenu;
    public Transform curtainTransform; //find and spawn curtain as child when exists in scene
    // Start is called before the first frame update

    private string currentCurtainTag = "Checkered";

    void Start()
    { 
        CreateButtons();
        rightMenu.SetActive(false);
        leftMenu.SetActive(false);
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
        if (curtainTransform != null)
        {
            foreach (GameObject curtain in curtain_list)
            {
                if (curtain_tag == curtain.tag)
                {
                    currentCurtain = InstantiateCurtain(curtain);
                    currentCurtain.transform.localPosition = new Vector3(0,-1.2f,0);
                    currentCurtainTag = curtain.tag;

                    rightMenu.SetActive(false);
                    rightMenu.SetActive(true);
                    colorChanger.GetComponent<ColourSelectionController>().UpdateColourPresets(currentCurtain);
                    opacitySlider.GetComponent<OpacityCustomiser>().UpdateCurtain(currentCurtain.GetComponent<Renderer>());
                    break;
                }
            }
        }
    }

    public GameObject InstantiateCurtain(GameObject curtainPrefab)
    {
        foreach (Transform child in curtainTransform)
        {
            GameObject.Destroy(child.gameObject);
        }
        GameObject curtain = Instantiate(curtainPrefab, curtainTransform);
        return curtain;
    }

    //public void FindCurtainTransform()
    //{
    //    curtainTransform = GameObject.FindGameObjectWithTag("curtainTransform").transform;
    //    leftMenu.SetActive(true);
    //    UpdateCurrentCurtain(currentCurtainTag);
    //}

    public void FindCurtainTransform(Transform cT)
    {
        curtainTransform = cT;
        leftMenu.SetActive(true);
        UpdateCurrentCurtain(currentCurtainTag);
    }

}
