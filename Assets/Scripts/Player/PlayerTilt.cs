using UnityEngine;

public class PlayerTilt : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Tilt();
    }

    private void Tilt()
    {
        if (_rigidbody.velocity.y < 0)
        {
            if (transform.rotation.z <= 30)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, -30), Time.deltaTime * 100);
            }
        }
        else
        {
            if (transform.rotation.z >= -30)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 30), Time.deltaTime * 100);
            }
        }
    }
}