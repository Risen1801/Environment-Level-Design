using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllFadeOut : MonoBehaviour
{
    FadeInOut fade;

    // Start is called before the first frame update
    void Start()
    {
        fade = FindObjectOfType<FadeInOut>();
        fade.fadeOut = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
