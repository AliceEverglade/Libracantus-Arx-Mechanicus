using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerOnClick : MonoBehaviour
{
    public GameObject TowerUI;
    bool Selected;
    public TMP_Text myButtonText;

    private void OnMouseDown()
    {
        if (TowerUI != null)
        {
            TowerUI.SetActive(true);
            Selected = true;
        }
    }
    private void OnMouseExit()
    {
        Selected = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Selected == false)
        {
            // Check if the click position is not over the button
            if (!RectTransformUtility.RectangleContainsScreenPoint(myButtonText.GetComponent<RectTransform>(), Input.mousePosition))
            {
                // Disable the GameObject
                TowerUI.SetActive(false);
            }
        }
    }
}
