using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private Animator anim;

    [SerializeField] private float jumpForce;

    private bool grounded;
    private bool gameOver = false;

    private string jumpTrigger = "Jump";
    private string groundTag = "Ground";
    private string obstacleTag = "Obstacle";
    private string deathAnim = "SantaDeath";


    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButton(0) && !gameOver)
        {
            if (grounded == true)
            {
                Jump();
            }
        }
    }

    private void Jump()
    {
        grounded = false;
        rigidBody.velocity = Vector2.up * jumpForce;
        anim.SetTrigger(jumpTrigger);
        GameManager.instance.IncrementScore();
    }

    private bool SetGameOverTrue()
    {
        return true;
    }

    private void OnCollisionEnter2D(Collision2D collision)   
    {
        if(collision.gameObject.tag == groundTag)
        {
            grounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == obstacleTag)
        {
            GameManager.instance.GameOver();
            Destroy(collision.gameObject);
            anim.Play(deathAnim);
            gameOver = SetGameOverTrue();
        }
    }
}
