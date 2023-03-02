using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    [SerializeField]
    private float blinkTime = 0.2f;
    private float timer;
    private bool isBlinking;

    private Renderer mesh;
    void Awake()
    {
        mesh = gameObject.GetComponent<Renderer>();
    }

    private void Start()
    {
        timer = 0;
        isBlinking = false;
    }

    private void Update()
    {
        isBlinking = LifeManager.Instance.isInvincible;
        if (isBlinking)
        {
            if (timer < blinkTime)
            {
                timer += Time.deltaTime;
            }
            else
            {
                timer = 0;
                Debug.Log(mesh.name + " is blinking!");
                if (mesh.enabled) mesh.enabled = false;
                else mesh.enabled = true;
            }

        }
        //Reactivate if object is still deactivated after invincible time
        if (!isBlinking && !mesh.enabled)
        {
            mesh.enabled = true;
        }

    }
}
