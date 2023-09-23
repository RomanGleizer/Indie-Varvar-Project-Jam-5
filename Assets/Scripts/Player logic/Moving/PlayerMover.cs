using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private float speed;
    private Rigidbody2D _rb;
    private Vector2 _movement;

    public bool isCurrentNpcChild;
    public bool isCurrentNpcGirl;

    private void Awake()
    {
        speed = 5f;
        _rb = GetComponent<Rigidbody2D>();
        InvokeRepeating(nameof(ResetSpeed), 1f, 1f);
    }

    private void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Child>()) isCurrentNpcChild = true;
        if (collision.GetComponent<Girl>()) isCurrentNpcGirl = true;
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _movement * speed * Time.deltaTime);
    }

    private void ResetSpeed()
    {
        if (speed > 5f) speed = 5f;
    }
}