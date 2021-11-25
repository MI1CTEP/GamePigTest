using UnityEngine;

public class Music : MonoBehaviour
{
    private static Music _music;
    private void Awake()
    {
        if (_music != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _music = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
