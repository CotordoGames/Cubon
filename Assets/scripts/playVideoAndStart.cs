using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using Unity.Properties;

public class playVideoAndStart : MonoBehaviour
{

    private VideoPlayer vp;
    public string scene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vp = GetComponent<VideoPlayer>();
        vp.source = VideoSource.Url;
        vp.url = Application.streamingAssetsPath + "/intro.mp4";
        vp.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(!vp.isPlaying && vp.time > 1f)
        {
            SceneManager.LoadScene(scene);
        }
    }
}
