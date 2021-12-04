using UnityEngine;
using UnityEngine.Events;

public class GeneratorContent : MonoBehaviour
{
    [SerializeField] private UnityEventInt SetAnswer;

    private Sprite[] _contents;

    public void SetContents(Sprite[] contents)
    {
        _contents = contents;
    }

    public Sprite[] Generate(int cells, ref int answer)
    {
        int[] randomIntArray = IntArray.CreateRandom(_contents.Length);
        int answerNewPosition = Random.Range(0, cells);
        int answerOldPosition = IntArray.FindIndex(randomIntArray, answer);
        randomIntArray = IntArray.RearrangeValues(randomIntArray, answerNewPosition, answerOldPosition);

        Sprite[] contents = new Sprite[cells];

        for (int i = 0; i < cells; i++)
            contents[i] = _contents[randomIntArray[i]];

        SetAnswer.Invoke(answer);
        answer = answerNewPosition;
        return contents;
    }
}
[System.Serializable]
public class UnityEventInt : UnityEvent<int> { }
