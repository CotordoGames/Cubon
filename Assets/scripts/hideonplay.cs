using UnityEngine;

public class hideonplay : MonoBehaviour
{
    private SpriteRenderer sr;
    private GameDebug debug;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        debug = FindAnyObjectByType<GameDebug>();
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        sr.enabled = debug.debug;
        
    }
}
