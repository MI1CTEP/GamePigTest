using UnityEngine;

public static class IntArray
{
    public static int[] CreateRandom(int length)
    {
        int[] array = new int[length];

        for (int i = 0; i < length; i++)
            array[i] = i;

        for (int i = 0; i < length; i++)
        {
            int tmp = array[i];
            int r = Random.Range(i, array.Length);
            array[i] = array[r];
            array[r] = tmp;
        }

        return array;
    }

    public static int[] RearrangeValues(int[] array, int first, int second)
    {
        int i = array[first];
        array[first] = array[second];
        array[second] = i;

        return array;
    }

    public static int FindIndex (int[] array, int value)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == value)
                return i;
        }
        return 0;
    }
}