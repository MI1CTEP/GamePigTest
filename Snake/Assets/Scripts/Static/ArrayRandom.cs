using UnityEngine;

public static class ArrayRandom
{
    public static int[] Create(int lenght)
    {
        int[] array = new int[lenght];
        for (int i = 0; i < lenght; i++)
            array[i] = i;

        for (int i = 0; i < lenght; i++)
        {
            int temporary = array[i];
            int random = Random.Range(i, lenght);
            array[i] = array[random];
            array[random] = temporary;
        }

        return array;
    }
}
