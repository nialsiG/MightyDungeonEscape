using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreDisplay;
    [SerializeField]
    private float deltaTimeScoreUpdate = 0.1f;
    private float timer;

    private int oldScore;
    private int newScore;


    private void Start()
    {
        oldScore = ServiceLocator.GetService<IScore>().GetScore();
        scoreDisplay.SetText(oldScore.ToString());
    }



    private void Update()
    {
        newScore = ServiceLocator.GetService<IScore>().GetScore();
        
        timer += Time.deltaTime;
        if (timer >= deltaTimeScoreUpdate)
        {
            timer = 0;
            ServiceLocator.GetService<IScore>().AddToScore(1);
        }

        if (oldScore != newScore)
        {
            scoreDisplay.SetText(newScore.ToString());
            oldScore = newScore;
        }
    }

}
