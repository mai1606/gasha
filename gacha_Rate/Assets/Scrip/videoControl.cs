using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class videoControl : MonoBehaviour
{
    public UnityEngine.Video.VideoPlayer videoPlayer;
    public string url_video = "";
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("SaveScenes"))
        {
            url_video = PlayerPrefs.GetString("SaveScenes");
        }
        else
        {
           // url_video = "SCREEN_SAVER.mp4";
        }
        url_video = "SCREEN_SAVER.mp4";
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playVideo()
    {
        videoPlayer.url = Application.streamingAssetsPath + "/video/"+staticVariable.videoName+".mp4";
        videoPlayer.isLooping = true;
        videoPlayer.Play();
    }
    public void stopVideo()
    {
        videoPlayer.Stop();
    }
}
