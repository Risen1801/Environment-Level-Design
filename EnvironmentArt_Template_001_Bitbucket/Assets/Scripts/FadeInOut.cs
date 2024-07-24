using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    public CanvasGroup CanvasGroup;
    public bool fadeIn = false;
    public bool fadeOut = false;

    public float TimeToFade;

    // Update is called once per frame
    void Update()
    {
        if (fadeIn)
        {
            if (CanvasGroup.alpha < 1)
            {
                CanvasGroup.alpha += TimeToFade * Time.deltaTime;

                if (CanvasGroup.alpha >= 1)
                {
                    fadeIn = false;
                }
            }
        }

        if (fadeOut)
        {
            if (CanvasGroup.alpha >= 0)
            {
                CanvasGroup.alpha -= TimeToFade * Time.deltaTime;

                if (CanvasGroup.alpha <= 0)
                {
                    fadeOut = false;
                }
            }
        }
    }
}
