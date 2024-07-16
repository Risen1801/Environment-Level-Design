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

    private Animator _animator;
    private int _isOpenParameterHash;
    private bool _isOpen;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _isOpenParameterHash = Animator.StringToHash("isOpen");

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
                    
                        Debug.Log("E key pressed. Player has key: " + PlayerInventory.HasKey + ". Current door state: " + _isOpen);
                        if (PlayerInventory.HasKey && !_isOpen)
                        {
                            Debug.Log("Opening locked door.");
                            interactionPopupKeyNeeded.SetActive(false);
                            interactionPopupHasKey.SetActive(false);
                            _animator.SetBool(_isOpenParameterHash, true);
                            _isOpen = true;
                        }

                        else if (PlayerInventory.HasKey && _isOpen)
                        {
                            Debug.Log("Closing locked door.");
                            interactionPopupKeyNeeded.SetActive(false);
                            interactionPopupHasKey.SetActive(false);
                            _animator.SetBool(_isOpenParameterHash, false);
                            _isOpen = false;
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
