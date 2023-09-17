using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public float speed;

    private Rigidbody2D _rb;
    private Vector2 _movement;

    public bool isCurrentNpcChild;
    public bool isCurrentNpcGirl;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
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
}