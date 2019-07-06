using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public bool playing = false;

    public void playVideo()
    {
        if (!playing)
        {
            videoPlayer.Play();
            playing = true;
        }
        else
        {
            videoPlayer.Stop();
            playing = false;
        }
            
    }
}
