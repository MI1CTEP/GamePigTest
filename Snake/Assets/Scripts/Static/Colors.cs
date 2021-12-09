using UnityEngine;

public static class Colors
{
    private static Color[] _colors = { Color.red, Color.green, Color.blue, Color.yellow, new Color(1, 0.5f, 0), Color.cyan };

    public static Color GetRandom(Color exception)
    {
        while (true)
        {
            int random = Random.Range(0, _colors.Length);
            if (_colors[random] != exception)
                return _colors[random];
        }
    }
}