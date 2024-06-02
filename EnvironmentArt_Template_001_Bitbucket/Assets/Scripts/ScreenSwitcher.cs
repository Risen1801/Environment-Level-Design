using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // Name der Szene, zu der gewechselt werden soll
    public string sceneName;

    // Diese Methode wird aufgerufen, wenn ein anderes Collider-Objekt in den Trigger-Box-Collider eintritt
    private void OnTriggerEnter(Collider other)
    {
        // �berpr�fen, ob das Objekt, das in den Collider eintritt, der Spieler ist
        if (other.CompareTag("Player"))
        {
            // Szene wechseln
            SceneManager.LoadScene(sceneName);
        }
    }
}