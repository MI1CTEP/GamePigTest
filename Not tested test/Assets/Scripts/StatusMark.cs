using UnityEngine;

public class StatusMark : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _mark;

    public void ActiveMark()
    {
        _mark.enabled = true;
    }
    public void DeactiveMark()
    {
        _mark.enabled = false;
    }
}
