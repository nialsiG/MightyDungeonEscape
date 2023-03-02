using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineOwlbear : MonoBehaviour
{
    private Animator owlbearAnimator;
    private enum OwlbearStates
    {
        waiting,
        combo
    }
    private OwlbearStates CurrentState = OwlbearStates.waiting;

    // Start is called before the first frame update
    void Start()
    {
        owlbearAnimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < 1 && gameObject.transform.position.y > 0 && CurrentState == OwlbearStates.waiting)
        {
            SoundManager.Instance.PlaySound(SoundManager.mySounds.owlbear);
            CurrentState = OwlbearStates.combo;
            owlbearAnimator.SetBool("Combo", true);
        }
    }
}
