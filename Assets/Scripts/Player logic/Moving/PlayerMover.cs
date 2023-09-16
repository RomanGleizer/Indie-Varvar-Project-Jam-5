using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public float speed;

    private Rigidbody2D _rb;
    private Vector2 _movement;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _movement * speed * Time.deltaTime);
    }
}