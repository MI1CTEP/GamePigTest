using UnityEngine;

public class ShufflingDeck : MonoBehaviour
{
    public Sprite[] Card;
    [HideInInspector] public int[] ArrayCard;
    [HideInInspector] public int nextCard = 4;

    private void Awake()
    {
        ArrayCard = new int[Card.Length];
        for (int i = 0; i < Card.Length; i++)
            ArrayCard[i] = i;
        ArrayCard = ShuffleArray(ArrayCard);
    }

    private int[] ShuffleArray(int[] arrayCard)
    {
        for (int i = 0; i < Card.Length; i++)
        {
            int tmp = arrayCard[i];
            int r = Random.Range(i, arrayCard.Length);
            arrayCard[i] = arrayCard[r];
            arrayCard[r] = tmp;
        }
        return arrayCard;
    }
}
