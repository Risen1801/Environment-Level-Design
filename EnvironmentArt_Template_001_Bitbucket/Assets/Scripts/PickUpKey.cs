using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpKey : MonoBehaviour
{
    public Camera playerCamera;
    public float interactionRange = 2f;
    public LayerMask interactableLayer;
    public GameObject interactionPopup2;

    private void Start()
    {
        // Stelle sicher, dass das Pop-up am Anfang deaktiviert ist
        if (interactionPopup2 != null)
        {
            interactionPopup2.SetActive(false);
        }
    }

    void Update()
    {
        // Überprüfe, ob der Spieler ein Objekt anschaut
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, interactionRange, interactableLayer))
        {
            if (hit.collider.gameObject.CompareTag("Key"))
            {
                // Zeige das Pop-up an
                if (interactionPopup2 != null)
                {
                    interactionPopup2.SetActive(true);
                }

                // Prüfe, ob der Spieler die Aufnahmetaste drückt
                if (Input.GetKeyDown(KeyCode.E))
                {
                    PlayerInventory.HasKey = true;
                    interactionPopup2.SetActive(false);
                    hit.collider.gameObject.SetActive(false);
                }
            }
        }
        else
        {
            // Verstecke das Pop-up, wenn der Spieler das Objekt nicht mehr anschaut
            if (interactionPopup2 != null)
            {
                interactionPopup2.SetActive(false);
            }
        }
    }
}

public static class PlayerInventory 
{
    public static bool HasKey = false;
}

