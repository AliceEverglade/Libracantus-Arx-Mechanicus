using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerOnClick : MonoBehaviour
{
    public enum TowerChoice
    {
        Fire,
        Ice,
        Poison,
        Magic,
        Heal
    }
    [SerializeField]
    private TowerChoice selectedTower;

    public GameObject TowerUI;
    bool Selected;
    public TMP_Text myButtonText;

    public GameObject FireIM;
    public GameObject IceIM;
    public GameObject PoisonIM;
    public GameObject MagicIM;
    public GameObject HealIM;

    private void OnMouseDown()
    {
        if (TowerUI != null)
        {
            TowerUI.SetActive(true);
            Selected = true;
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.2f);

        Selected = false;

        if (selectedTower == TowerChoice.Fire)
        {
            FireIM.SetActive(true);
        }
        if (selectedTower == TowerChoice.Ice)
        {
            IceIM.SetActive(true);
        }
        if (selectedTower == TowerChoice.Poison)
        {
            PoisonIM.SetActive(true);
        }
        if (selectedTower == TowerChoice.Magic)
        {
            MagicIM.SetActive(true);
        }
        if (selectedTower == TowerChoice.Heal)
        {
            HealIM.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        StartCoroutine(Delay());
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
                IceIM.SetActive(false);
                FireIM.SetActive(false);
                PoisonIM.SetActive(false);
                MagicIM.SetActive(false);
                HealIM.SetActive(false);
            }
        }
    }
}
