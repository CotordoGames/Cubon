using UnityEngine;

public class bounce : MonoBehaviour
{
    PlayerMovement PM;
    Rigidbody2D rb;
    public int bounceheight;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PM = collision.gameObject.GetComponent<PlayerMovement>();
            rb = collision.gameObject.GetComponent<Rigidbody2D>();
            anim.SetTrigger("bounce");
            rb.linearVelocity = new Vector2(rb.linearVelocityX, bounceheight);
        }
    }
}
