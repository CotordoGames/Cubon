using System.Collections;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    public BoxCollider2D feet;
    public LayerMask Water;
    private PlayerMovement pm;
    private watermovement wm;
    public DialogueManager dm;
    private Rigidbody2D rb;
    private GameDebug gd;
    private NoclipMovementt ncm;
    public CapsuleCollider2D body;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pm = GetComponent<PlayerMovement>();
        wm = GetComponent<watermovement>();
        pm.enabled = true;
        wm.enabled = false;
        gd = FindAnyObjectByType<GameDebug>();
        ncm = GetComponent<NoclipMovementt>();
        ncm.enabled = false;
        body.enabled = true;   
    }

    // Update is called once per frame
    void Update()
    {
        if (!gd.debug)
        {
            ncm.enabled = false;
            if (dm.istalking)
            {
                pm.enabled = false;
                wm.enabled = false;
            }
            else if (Swimming() && !dm.istalking)
            {
                rb.gravityScale = 1f;
                pm.IsSlamming = false;
                pm.CanDash = true;
                pm.enabled = false;
                wm.enabled = true;
            }
            else if (!Swimming() && !dm.istalking)
            {
                if (!pm.IsDash)
                {
                    rb.gravityScale = 3f;
                }
                pm.enabled = true;
                wm.enabled = false;
            }
        }
        else
        {
            if(Input.GetKeyDown("2"))
            {
                pm.enabled = !pm.enabled;
                ncm.enabled = !ncm.enabled;
                if (ncm.enabled)
                {
                    body.enabled = false;
                    rb.gravityScale = 0f;
                }
                else
                {
                    body.enabled = true;
                    rb.gravityScale = 3f;
                }
            }
        }
        
    }

    public bool Swimming()
    {
        return Physics2D.BoxCast(feet.bounds.center, feet.bounds.size, 0f, Vector2.down, .1f, Water);
    }
}
