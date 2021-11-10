using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private Camera _camera;

    private void Awake()
    {
        _camera = FindObjectOfType<Camera>();
    }

    void FixedUpdate()
    {
        _camera.transform.position = new Vector3(transform.position.x, 4.5f, -10);
    }
}