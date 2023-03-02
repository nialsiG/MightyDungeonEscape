using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineKobold : MonoBehaviour
{
    private Animator koboldAnimator;
    private enum koboldStates
    {
        waiting,
        laughing
    }
    private koboldStates CurrentState = koboldStates.waiting;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < 1 && gameObject.transform.position.y > 0 && CurrentState == koboldStates.waiting)
        {
            CurrentState = koboldStates.laughing;
            SoundManager.Instance.PlaySound(SoundManager.mySounds.cackle);
        }
    }
}
