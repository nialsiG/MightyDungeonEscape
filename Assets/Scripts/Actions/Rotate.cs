using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 30;
 
    void Start()
    {
    }

    void Update()
    {
        gameObject.transform.Rotate(new Vector3(0, 1, 0), Time.deltaTime * rotationSpeed);
    }
}
