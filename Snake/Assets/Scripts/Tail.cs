using UnityEngine;

public class Tail : MonoBehaviour
{
    [SerializeField] private Transform[] _segments;

    public void Move(Vector3 destinationPoint, float tailSpringness)
    {
        foreach (var segment in _segments)
        {
            Vector3 segmentPosition = segment.position;
            segment.position = Vector3.Lerp(segment.position, destinationPoint, tailSpringness);
            segment.LookAt(destinationPoint);
            destinationPoint = segmentPosition;
        }
    }
}