using Core;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] private bool canMove, hasGameStarted;
    [SerializeField] private float speed;

    private void Awake() => GameManager.Instance.OnGameStartEvent += delegate { hasGameStarted = true; };

    private void Update()
    {
        if (!canMove || !hasGameStarted) return;
        transform.Translate(Vector3.left * (Time.deltaTime * speed), Space.World);
        if (transform.position.x <= -6)
            transform.position = new Vector3(6, Random.Range(-2.55f, 2.55f), 0);
    }
}