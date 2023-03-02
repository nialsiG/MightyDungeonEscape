using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public void QuitGame()
    {
        int currentGold = ServiceLocator.GetService<IGold>().GetGold();
        ServiceLocator.GetService<IScore>().AddToScore(currentGold);

        int currentScore = ServiceLocator.GetService<IScore>().GetScore();
        Debug.Log("Score: " + currentScore);

        gameObject.GetComponent<ChangeScene>().Title();
    }

    public void BribeGuards()
    {
        ServiceLocator.GetService<IGold>().AddToGold(-500);

        int currentGold = ServiceLocator.GetService<IGold>().GetGold();
        Debug.Log("Gold: " + currentGold);

        gameObject.GetComponent<ChangeScene>().RestartGame();
    }
}
