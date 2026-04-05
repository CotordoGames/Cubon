using UnityEngine;
using UnityEngine.UI;

public class GameDebug : MonoBehaviour
{
    public Text fps;
    public bool debug;
    private bool uncapped;

    public float updateInterval = 1f;

    private float lastFrameTime;

    private int framesCount;

    private float framespersecond;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        debug = false;
        fps.enabled = false;
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        //displayFPS
        float time = Time.time;

        framesCount++;



        if (time > lastFrameTime + updateInterval)

        {

            framespersecond = (float)framesCount / (time - lastFrameTime);

            lastFrameTime = time;

            framesCount = 0;



            fps.text = "FPS: " + Mathf.RoundToInt(framespersecond);

        }



        if (Input.GetKeyDown(KeyCode.F5) && !debug)
        {
            debug = true;
        } 
        else if (Input.GetKeyDown(KeyCode.F5) && debug)
        {
            debug = false;
        }
        fps.enabled = debug;

        if (debug)
        {
            if (Input.GetKeyDown("1"))
            {
                uncapped = !uncapped;
                if(uncapped)
                {
                    Application.targetFrameRate = 65536;
                }
                else
                {
                    Application.targetFrameRate = 60;
                }
            }
        }
    }
}
