using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OpenLockedDoors : MonoBehaviour
{
    public Camera playerCamera;
    public float interactionRange = 1f;
    public LayerMask interactableLayer;
    public GameObject interactionPopupKeyNeeded;
    public GameObject interactionPopupHasKey;

    private void Start()
    {
        // Stelle sicher, dass das Pop-up am Anfang deaktiviert ist
        if (interactionPopupKeyNeeded != null)
        {
            interactionPopupKeyNeeded.SetActive(false);
        }
        if (interactionPopupHasKey != null)
        {
            interactionPopupHasKey.SetActive(false);
        }
    }

    void Update()
    {
           // Überprüfe, ob der Spieler ein Objekt anschaut
           RaycastHit hit;
           if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, interactionRange, interactableLayer))
           {
               if (hit.collider.gameObject.CompareTag("LockedDoor"))
               {
                   // Zeige das Pop-up an, wenn der Schlüssel noch nicht aufgesammelt wurde
                   if (interactionPopupKeyNeeded != null && PlayerInventory.HasKey == false)
                   {
                       interactionPopupKeyNeeded.SetActive(true);
                   }

                   // Zeige das Pop-up an, wenn der Schlüssel aufgesammelt wurde
                   if (interactionPopupHasKey != null && PlayerInventory.HasKey == true)
                   {
                       interactionPopupHasKey.SetActive(true);
                   }

                   // Prüfe, ob der Spieler die Aufnahmetaste drückt
                   if (Input.GetKeyDown(KeyCode.E))
                   {
                       if (PlayerInventory.HasKey == true)
                       {
                           interactionPopupKeyNeeded.SetActive(false);
                           interactionPopupHasKey.SetActive(false);
                           Destroy(hit.collider.gameObject);
                       }
                   }
               }
           }
           else
           {
               // Verstecke das Pop-up, wenn der Spieler das Objekt nicht mehr anschaut
               if (interactionPopupKeyNeeded != null)
               {
                   interactionPopupKeyNeeded.SetActive(false);
               }
               if (interactionPopupHasKey != null)
               {
                   interactionPopupHasKey.SetActive(false);
               }
           } 
    }
}
