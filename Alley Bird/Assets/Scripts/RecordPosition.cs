using UnityEngine;

public class RecordPosition : MonoBehaviour
{
    [SerializeField] private float _startPositionY;
    [SerializeField] private float _positionStep;

    private void Awake()
    {
        float positionY = _startPositionY + _positionStep * PlayerPrefs.GetInt("RECORD");
        transform.position = new Vector3(0, positionY, -0.01f);
    }
}