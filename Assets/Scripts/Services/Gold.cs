using System.Collections;
using System.Collections.Generic;

public interface IGold
{
    public int GetGold();
    public void SetGold(int value);
    public void AddToGold(int amount);
    public void RemoveFromGold(int amount);

}

public class Gold : IGold
{
    protected int gold { get; private set; }

    public int GetGold()
    {
        return gold;
    }
    public void SetGold(int value)
    {
        gold = value;
    }

    public void AddToGold(int amount)
    {
        gold += amount;
    }

    public void RemoveFromGold(int amount)
    {
        gold += amount;
    }
}
