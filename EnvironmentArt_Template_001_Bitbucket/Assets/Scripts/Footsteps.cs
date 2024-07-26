using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public GameObject footstep;

    // Start is called before the first frame update
    void Start()
    {
        footstep.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // When walking, activate Sound
        if(Input.GetKey(KeyCode.W))
        {
            footsteps();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            footsteps();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            footsteps();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            footsteps();
        }

        //When not walking, deactivate Sound
        if (Input.GetKeyUp(KeyCode.W))
        {
            stopfootsteps();
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            stopfootsteps();
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            stopfootsteps();
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            stopfootsteps();
        }
    }

    void footsteps()
    {
        footstep.SetActive(true);
    }

    void stopfootsteps()
    {
        footstep.SetActive(false);
    }
}
