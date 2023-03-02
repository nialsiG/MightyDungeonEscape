using System;

public static class Util
{
    public static Random random = new Random();

    public static void SetRandomSeed(int seed)
    {
        random = new Random(seed);
    }
    public static int RandomInt(int min, int max)
    {
        return random.Next(min, max + 1);
    }
}