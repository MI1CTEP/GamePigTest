using UnityEngine;
using UnityEngine.UI;

public class Record : MonoBehaviour
{
    [SerializeField] private Text _record;

    private void Start()
    {
        _record.text = "RECORD: " + PlayerPrefs.GetInt("RECORD").ToString();
    }

    public void SaveRecord(int record)
    {
        PlayerPrefs.SetInt("RECORD: ", record);
    }
}
