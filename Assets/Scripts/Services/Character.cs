using System.Collections;
using System.Collections.Generic;
using SQLite;

public interface IChar
{
    public int GetCharacter();
    public int GetHP();
    public int GetAgility();
    public void SetCharacter(int value);
}

public class Character : IChar
{
    protected int character { get; private set; }

    public void SetCharacter(int value)
    {
        character = value;

        //var db = new SQLiteConnection(dataPath + "/DB.db");

    }

    public int GetCharacter()
    {
        return character;
    }

    public int GetHP()
    {
        int hp = 5;
        return hp;
    }

    public int GetAgility()
    {
        int agility = 5;
        return agility;
    }
}
