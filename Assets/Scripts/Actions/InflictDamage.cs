using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InflictDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!LifeManager.Instance.isInvincible)
        {
            Debug.Log("Damage inflicted!");
            SoundManager.Instance.PlaySound(SoundManager.mySounds.wound);
            LifeManager.Instance.LoseLife();
            LifeManager.Instance.SwitchInvicibility();
        }
        
    }
}
