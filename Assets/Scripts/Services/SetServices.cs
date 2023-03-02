using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetServices : MonoBehaviour
{
    public Gold currentGold;
    public Score currentScore;
    public Character currentChar; 

    // Start is called before the first frame update
    public void ResetServices()
    {
        currentGold = new Gold();
        ServiceLocator.RegisterService<IGold>(currentGold);
        currentGold.SetGold(300);

        currentScore = new Score();
        ServiceLocator.RegisterService<IScore>(currentScore);
        currentScore.SetScore(0);

        currentChar = new Character();
        ServiceLocator.RegisterService<IChar>(currentChar);

        int currentlySelected = gameObject.GetComponentInParent<CharacterSelection>().GetCurrentSelection();
        currentChar.SetCharacter(currentlySelected);
    }

}
