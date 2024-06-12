using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    public Camera playerCamera;
    public float interactionRange = 2f;
    public LayerMask interactableLayer;
    public GameObject interactionPopup3;

    private void Start()
    {
        // Stelle sicher, dass das Pop-up am Anfang deaktiviert ist
        if (interactionPopup3 != null)
        {
            interactionPopup3.SetActive(false);
        }
    }

    void Update()
    {
        // Überprüfe, ob der Spieler ein Objekt anschaut
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, interactionRange, interactableLayer))
        {
            if (hit.collider.gameObject.CompareTag("Item"))
            {
                // Zeige das Pop-up an
                if (interactionPopup3 != null)
                {
                    interactionPopup3.SetActive(true);
                }
            }
        }
        else
        {
            // Verstecke das Pop-up, wenn der Spieler das Objekt nicht mehr anschaut
            if (interactionPopup3 != null)
            {
                interactionPopup3.SetActive(false);
            }
        }
    }
}
