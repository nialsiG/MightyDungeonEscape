using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("You collected gold!");

        SoundManager.Instance.PlaySound(SoundManager.mySounds.coinsShort);    
        //add gold
        ServiceLocator.GetService<IGold>().AddToGold(50);
        //destroy loot
        Destroy(gameObject);
    }
}
