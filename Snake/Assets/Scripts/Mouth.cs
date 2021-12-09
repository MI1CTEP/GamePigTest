using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Mouth : MonoBehaviour
{
    [HideInInspector] public bool FeverMode;

    [SerializeField] private Transform[] _body;

    public UnityEvent OnDigestion;
    public UnityEvent OnPickedUpCrystal;
    public UnityEvent OnEatPoison;

    public void Digestion()
    {
        OnDigestion.Invoke();
        if (!FeverMode)
            StartCoroutine(StartAnimation());
    }

    private IEnumerator StartAnimation()
    {
        foreach (var body in _body)
        {
            body.localScale *= 1.1f;
            yield return new WaitForSeconds(0.1f);
            body.localScale /= 1.1f;
        }
    }
}