using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject mainCanvas;
    // Start is called before the first frame update
    void Start()
    {
        if (mainCanvas == null)
        {
            mainCanvas = GameObject.FindWithTag("mainCanvas");
        }
    }

    public void SelectCurtain()
    {
        mainCanvas.GetComponent<CurtainController>().UpdateCurrentCurtain(gameObject.tag);
    }
}
