using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurtainController : MonoBehaviour
{
    public List<GameObject> curtain_list = new List<GameObject>();
    public GameObject currentCurtain;
    public GameObject button;
    public GameObject scroll;
    public GameObject opacityChanger;
    public GameObject colorChanger;
    // Start is called before the first frame update

    void Start()
    { 
        createButtons(); 
    }

    public void createButtons(){
        for(int i=0;i<curtain_list.Count;i++){
            string curtain = curtain_list[i].tag;
            GameObject button_inst = Instantiate(button, scroll.transform);
            button_inst.transform.GetChild(0).GetComponent<Text>().text = curtain;
            button_inst.tag = curtain;
        }
    }

    public void updateCurrentCurtain(string curtain)
    {
        for(int i=0;i<curtain_list.Count;i++){
            string curtain_tag = curtain_list[i].tag;
            if(curtain_tag == curtain){
                currentCurtain = curtain_list[i];
                break;
            }
        }
        colorChanger.GetComponent<ColourSelectionController>().UpdateColourPresets(currentCurtain);
        opacityChanger.GetComponent<OpacityCustomiser>().UpdateColourPresets(currentCurtain.GetComponent<Renderer>());
    }
}
