using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private readonly Vector2 _force = new Vector2(0, 5);

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        MoveForward();
    }

    public void ApplyImpulse()
    {
        _rigidbody.AddForce(_force, ForceMode2D.Impulse);
    }

    private void MoveForward()
    {
        transform.position += new Vector3(0.05f, 0, 0);
    }
}