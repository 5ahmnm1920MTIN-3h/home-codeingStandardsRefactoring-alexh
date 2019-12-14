using UnityEngine;

public class Obstacle : MonoBehaviour
{

    private Rigidbody2D rigidBody;
    [SerializeField] private float moveSpeed;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if obstacle's position x is < -15f it will be destroyed
        if(transform.position.x < -15f)
        {
            Destroy(gameObject);
        }

        //if obstacle's position x is < -15f it will be destroyed
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
