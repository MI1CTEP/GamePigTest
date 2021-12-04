using UnityEngine;
using UnityEngine.UI;

public class TaskUI : MonoBehaviour
{
    [SerializeField] private Text _answerText;

    private string[] _nameContent;

    public void GetNames(string[] nameContent)
    {
        _nameContent = nameContent;
    }

    public void ShowTask(int answer)
    {
        _answerText.text = $"Find {_nameContent[answer]}";
    }
}
