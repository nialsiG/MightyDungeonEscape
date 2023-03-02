using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public enum mySounds
    {
        coinsShort,
        coinsLong,
        footstepLeft,
        footstepRight,
        gateOpen,
        gateClose,
        wound,
        fall,
        cackle,
        owlbear
    }

    [SerializeField]
    private AudioClip[] sounds;

    //Singleton
    public static SoundManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }


    public void PlaySound(mySounds sound)
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = sounds[(int)sound];
        audioSource.PlayOneShot(audioSource.clip);
        Debug.Log("Playing" + audioSource.clip.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
