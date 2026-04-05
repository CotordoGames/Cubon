
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class chuck_follow : MonoBehaviour
{

    public Transform player;
    public float moveSpeed;
    public float jumpheight;
    private Rigidbody2D rb;
    public int dir;
    public float accel;
    public BoxCollider2D feet;
    public LayerMask Ground;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector2(Mathf.Lerp(rb.linearVelocityX,moveSpeed * dir, accel * Time.deltaTime * 55), rb.linearVelocity.y);
        if(transform.position.x < player.position.x)
        {
            dir = 1;
        }
        else if (transform.position.x > player.position.x)
        {
            dir = -1;
        }

        if(transform.position.y < player.position.y && isGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpheight);
        }
    }

    public bool isGrounded()
    {
        return Physics2D.BoxCast(feet.bounds.center, feet.bounds.size, 0f, Vector2.down, .1f, Ground);
    }
}
