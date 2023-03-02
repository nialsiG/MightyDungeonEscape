using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{
    protected bool IsFadingIn { get; private set; }
    protected bool IsFadingOut { get; private set; }
    private Image image;

    public void FadeOut()
    {
        IsFadingOut = true;
        //Let the user click through
        if (image.raycastTarget)
        {
            image.raycastTarget = false;
        }

    }

    public void FadeIn()
    {
        IsFadingIn = true;
        //Do NOT let the user click through
        if (!image.raycastTarget)
        {
            image.raycastTarget = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    void FixedUpdate()
    {
        if (image.color.a < 1 && IsFadingIn)
        {
            Color color = image.color;
            color.a += 0.2f;
            image.color = color;
            if (image.color.a == 1)
            {
                IsFadingIn = false;
            }
        }

        if (image.color.a > 0 && IsFadingOut)
        {
            Color color = image.color;
            color.a -= 0.01f;
            image.color = color;
            if (image.color.a == 0)
            {
                IsFadingOut = false;
            }
        }
    }
}
