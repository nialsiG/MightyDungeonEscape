using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip audioClip;

    void Start()
    {
        if(audioClip != null)
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = audioClip;
            audioSource.volume = 1;
            audioSource.loop = true;
            Debug.Log("Playing" + audioClip.name);
            audioSource.Play();
        }
        
    }
}
