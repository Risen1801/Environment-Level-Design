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
    private int _isOpenParameterHash;
    private bool _isOpen;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _isOpenParameterHash = Animator.StringToHash("isOpen");

        // Stelle sicher, dass das Pop-up am Anfang deaktiviert ist
        if (interactionPopup1 != null)
        {
            interactionPopup1.SetActive(false);
        }
        Debug.Log("Animator and parameter hash initialized.");
    }

    void Update()
    {
        // Überprüfe, ob der Spieler ein Objekt anschaut
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

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("E key pressed. Current door state: " + _isOpen);
                    if (!_isOpen)
                    {
                        Debug.Log("Opening door.");
                        _animator.SetBool(_isOpenParameterHash, true);
                        _isOpen = true;
                    }

                    else if (_isOpen)
                    {
                        Debug.Log("Closing door.");
                        _animator.SetBool(_isOpenParameterHash, false);
                        _isOpen = false;
                    }

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
