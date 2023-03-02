using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    private void LeftStep()
    {
        SoundManager.Instance.PlaySound(SoundManager.mySounds.footstepLeft);
    }
    private void RightStep()
    {
        SoundManager.Instance.PlaySound(SoundManager.mySounds.footstepRight);
    }
}
