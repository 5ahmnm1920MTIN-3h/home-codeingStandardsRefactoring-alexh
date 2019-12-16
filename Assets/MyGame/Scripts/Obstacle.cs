using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float leftBoundary = -15f;
    [SerializeField] private float rightBoundary = 15f;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (transform.position.x > rightBoundary)
        {
            Destroy(gameObject);
        }

        else if (transform.position.x < leftBoundary)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        rigidBody.velocity = Vector2.left * moveSpeed;
    }
}
