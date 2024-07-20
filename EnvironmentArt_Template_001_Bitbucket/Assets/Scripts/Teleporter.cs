using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform destination_Horse1;
    public Transform destination_Horse2;
    public Transform destination_Horse3;
    public Transform destination_Horse4;
    public Transform destination_Horse5;
    private void OnTriggerEnter(Collider other)
    {

        //Horse_1
        if (destination_Horse1 != null && other.CompareTag("Horse_1"))
        {
            // Setze die Position des Objektes auf die Position der Destination
            other.transform.position = destination_Horse1.position;
            other.transform.rotation = destination_Horse1.rotation;
            Debug.Log("Teleported Horse_1");
        }

        //Horse_2
        if (destination_Horse2 != null && other.CompareTag("Horse_2"))
        {
            // Setze die Position des Objektes auf die Position der Destination
            other.transform.position = destination_Horse2.position;
            other.transform.rotation = destination_Horse2.rotation;
            Debug.Log("Teleported Horse_2");
        }

        //Horse_3
        if (destination_Horse3 != null && other.CompareTag("Horse_3"))
        {
            // Setze die Position des Objektes auf die Position der Destination
            other.transform.position = destination_Horse3.position;
            other.transform.rotation = destination_Horse3.rotation;
            Debug.Log("Teleported Horse_3");
        }

        //Horse_4
        if (destination_Horse4 != null && other.CompareTag("Horse_4"))
        {
            // Setze die Position des Objektes auf die Position der Destination
            other.transform.position = destination_Horse4.position;
            other.transform.rotation = destination_Horse4.rotation;
            Debug.Log("Teleported Horse_4");
        }

        //Horse_5
        if (destination_Horse5 != null && other.CompareTag("Horse_5"))
        {
            // Setze die Position des Objektes auf die Position der Destination
            other.transform.position = destination_Horse5.position;
            other.transform.rotation = destination_Horse5.rotation;
            Debug.Log("Teleported Horse_5");
        }

    }
}
