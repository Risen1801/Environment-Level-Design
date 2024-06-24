using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDoors : MonoBehaviour
{
    public Camera playerCamera;
    public float interactionRange = 1f;
    public LayerMask interactableLayer;
    public GameObject interactionPopup1;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();

        // Stelle sicher, dass das Pop-up am Anfang deaktiviert ist
        if (interactionPopup1 != null)
        {
            interactionPopup1.SetActive(false);
        }
    }

    void Update()
    {
        // �berpr�fe, ob der Spieler ein Objekt anschaut
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, interactionRange, interactableLayer))
        {

            if (hit.collider.gameObject.CompareTag("Door"))
            { 

                // Zeige das Pop-up an
                if (interactionPopup1 != null)
                {
                    interactionPopup1.SetActive(true);
                }

                // Pr�fe, ob der Spieler die Aufnahmetaste dr�ckt
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactionPopup1.SetActive(false);
                    _animator.SetBool("isOpen", true);
                }

            }
        }
        else
        {
            // Verstecke das Pop-up, wenn der Spieler das Objekt nicht mehr anschaut
            if (interactionPopup1 != null)
            {
                interactionPopup1.SetActive(false);
            }
        }
    }
}
