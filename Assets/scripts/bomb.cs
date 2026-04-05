using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class bomb : MonoBehaviour
{
    public GameObject exp;
    public CircleCollider2D cc;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cc.enabled = false;
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(BOOM());
        }
    }

    IEnumerator BOOM()
    {
        yield return new WaitForSeconds(3);
        Instantiate(exp, transform, false);
        cc.enabled = true;
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
