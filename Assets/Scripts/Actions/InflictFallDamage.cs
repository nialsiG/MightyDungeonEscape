using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InflictFallDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!LifeManager.Instance.GetIsFallen())
        {
            Debug.Log("You fell!");
            SoundManager.Instance.PlaySound(SoundManager.mySounds.fall);
            LifeManager.Instance.SetIsFallen();
        }

    }
}
