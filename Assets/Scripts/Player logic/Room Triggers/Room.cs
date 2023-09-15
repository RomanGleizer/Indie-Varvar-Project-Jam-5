using UnityEngine;

public class Room : MonoBehaviour
{
    private int _number;
    private Vector3 _startPosition;

    public int Number => _number;
    public Vector3 StartPosition => _startPosition;

    private void Awake()
    {
        _startPosition = transform.position;
        _number = transform.GetSiblingIndex();
    }
}