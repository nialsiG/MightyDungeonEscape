using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScore
{
    public int GetScore();
    public void SetScore(int value);
    public void AddToScore(int amount);
}
public class Score : IScore
{
    protected int score { get; private set; }

    public int GetScore()
    {
        return score;
    }
    public void SetScore(int value)
    {
        score = value;
    }

    public void AddToScore(int amount)
    {
        score += amount;
    }
}
