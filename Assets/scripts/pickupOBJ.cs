using System.Collections;
using UnityEngine;

public class pickupOBJ : MonoBehaviour
{
    private PlayerMovement pm;
    public bool carrying;
    private GameObject holdReference;

    private void Start()
    {
        pm = GetComponent<PlayerMovement>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("pickup") && pm.IsDash)
        {
            holdReference = collision.gameObject;
            carrying = true;
            collision.transform.SetParent(transform, false);
            collision.transform.localPosition = new Vector2(0, 0.8f);
            holdReference.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            holdReference.GetComponent<Collider2D>().enabled = false;
            pm.rb.linearVelocity = new Vector2(0, pm.rb.linearVelocityY);
        }
    }

    private void Update()
    {
        if (carrying)
        {
            pm.CanDash = false;
            if (Input.GetKeyDown("x") || !holdReference)
            {
                carrying = false;
                holdReference.transform.SetParent(null, true);
                holdReference.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                holdReference.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(8 * (pm.rb.linearVelocityX / 5), 4);
                holdReference.GetComponent<Collider2D>().enabled = true;
                StartCoroutine(RestoreDash());
                holdReference = null;
                
            }
        }
    }

    IEnumerator RestoreDash()
    {
        yield return new WaitForSeconds(.01f);
        
        pm.CanDash = true;
    }

}
