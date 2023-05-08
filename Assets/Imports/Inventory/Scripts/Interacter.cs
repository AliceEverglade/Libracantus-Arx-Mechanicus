using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacter : MonoBehaviour
{
    public Transform InteractionPoint;
    public LayerMask InteractionLayer;
    public float InteractionPointRadius = 1f;
    public bool IsInteracting { get; private set; }

    [SerializeField] private List<GameObject> UIList = new List<GameObject>();

    private void Update()
    {
        var colliders = Physics2D.OverlapCircleAll(InteractionPoint.position, InteractionPointRadius, InteractionLayer);

        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("f pressed");
            for (int i = 0; i < colliders.Length; i++)
            {
                Debug.Log(colliders[i].name);
                CheckCol(colliders[i]);
                var interactable = colliders[i].GetComponent<IInteractable>();

                if(interactable != null)
                {
                    StartInteraction(interactable);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            foreach (var UI in UIList)
            {
                UI.SetActive(false);
            }
        }
    }

    private void StartInteraction(IInteractable interactable)
    {
        interactable.Interact(this, out bool interactSuccessful);
        IsInteracting = true;
    }

    private void EndInteraction()
    {
        IsInteracting = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(InteractionPoint.position, InteractionPointRadius);
    }

    private void CheckCol(Collider2D hit)
    {
        switch (hit.name)
        {
            case "Cauldron":
                UIList[0].SetActive(true);
                break;
            case "Crates":
                UIList[5].SetActive(true);
                break;
            case "Storage":
                UIList[1].SetActive(true);
                break;

        }
    }
}
