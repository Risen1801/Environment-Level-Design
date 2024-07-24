using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // Name der Szene, zu der gewechselt werden soll
    public string sceneName;

    FadeInOut fade;

    private void Start()
    {
        fade = FindObjectOfType<FadeInOut>();
    }

    public IEnumerator ChangeScene()
    {
        fade.fadeIn = true;
        yield return new WaitForSeconds(fade.TimeToFade);
        SceneManager.LoadScene(sceneName);
    }

    // Diese Methode wird aufgerufen, wenn ein anderes Collider-Objekt in den Trigger-Box-Collider eintritt
    private void OnTriggerEnter(Collider other)
    {
        // Überprüfen, ob das Objekt, das in den Collider eintritt, der Spieler ist
        if (other.CompareTag("Player"))
        {
            // Szene wechseln
            StartCoroutine(ChangeScene());
        }
    }
}