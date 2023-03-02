using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRotation : MonoBehaviour
{
    [SerializeField]
    float Speed = 50;
    [SerializeField]
    float TowerHeight = 14.4f;
    public bool toDestroy = false;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0), Speed * Time.deltaTime);
        transform.Translate(0, - TowerHeight / 360 * Speed * Time.deltaTime, 0);
    }

    private void LateUpdate()
    {
        if (toDestroy)
        {
            Destroy(gameObject);
        }
    }
}
