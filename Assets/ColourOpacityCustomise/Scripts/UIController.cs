using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour
{
    public GameObject CollapsableUI;
    public GameObject ButtonArrow;
    public bool collapsed = true;

    void Start()
    {
        ToggleCollapse();
    }

    public void ToggleCollapse()
    {
        if (collapsed)
        {
            CollapsableUI.SetActive(true);
            ButtonArrow.transform.localRotation = Quaternion.Euler(0f, 0f, -90f);
            collapsed = false;
        }
        else 
        {
            CollapsableUI.SetActive(false);
            ButtonArrow.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
            collapsed = true;
        }

    }
}
