using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneActivator : MonoBehaviour
{
    public GameObject CutSceneObject;
    public GameObject PlayerObject;
    public AudioSource AudioSource;
    public AudioClip AudioClip;
    public GameObject InteractionPopUpWaiting;
    public GameObject Crosshair;

    FadeInOut fade;
    bool playerInTrigger = false;

    void Start()
    {
        AudioSource.clip = AudioClip;
        AudioSource.playOnAwake = false;

        if (InteractionPopUpWaiting != null)
        {
            InteractionPopUpWaiting.SetActive(false);
        }

        fade = FindObjectOfType<FadeInOut>();
    }

    private void Update()
    {
        if (playerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E Pressed");
            StartCoroutine(CutScene());
        }
    }

    public IEnumerator CutScene()
    {
        Debug.Log("Start Coroutine");
        fade.fadeIn = true;
        yield return new WaitForSeconds(fade.TimeToFade);
        PlayerObject.SetActive(false);
        CutSceneObject.SetActive(true);
        InteractionPopUpWaiting.SetActive(false);
        Crosshair.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayOneShot(AudioClip);
            if (InteractionPopUpWaiting != null)
            {
                InteractionPopUpWaiting.SetActive(true);
            }

            playerInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (InteractionPopUpWaiting != null)
            {
                InteractionPopUpWaiting.SetActive(false);
            }
        }
    }
}
