using UnityEngine;

public class Obstacle : MonoBehaviour
{

    private Rigidbody2D rigidBody;
    [SerializeField] private float moveSpeed;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(transform.position.x < -15f)
        {
            Destroy(gameObject);
        }

        if (transform.position.x > 15f)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        rigidBody.velocity = Vector2.left * moveSpeed;
    }
}
