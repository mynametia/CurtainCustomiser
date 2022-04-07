using UnityEngine;

public class UiController : MonoBehaviour
{
    public GameObject CollapsableUI;
    public GameObject ButtonArrow;
    public bool collapsed = true;
    public int reverse = 1;

    void Start()
    {
        ToggleCollapse();
    }

    public void ToggleCollapse()
    {
        if (collapsed)
        {
            CollapsableUI.SetActive(true);
            ButtonArrow.transform.localRotation = Quaternion.Euler(0f, 0f, -90f*reverse);
            collapsed = false;
        }
        else 
        {
            CollapsableUI.SetActive(false);
            ButtonArrow.transform.localRotation = Quaternion.Euler(0f, 0f, 90f*reverse);
            collapsed = true;
        }

    }
}
