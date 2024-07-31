using UnityEngine;

public static class Randomizer
{
    public static object GetObjectFromArray(object[] array)
    {
        return array[Random.Range(0, array.Length)];
    }

    public static int GetNumber(int min, int max)
    {
        return Random.Range(min, max + 1);
    }
}
