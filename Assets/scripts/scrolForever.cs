using UnityEngine;

public class scrolForever : MonoBehaviour
{
    public float speed;
    public float maxdist;
    Vector2 pos = Vector2.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = pos;
        pos.x += speed;
        if(pos.x < maxdist)
        {
            pos.x = 20;
        }
    }
}
