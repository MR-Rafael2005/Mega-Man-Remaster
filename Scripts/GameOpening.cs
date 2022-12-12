using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class GameOpening : MonoBehaviour
{
    private VideoPlayer vPlayer;
    private bool loading = false;

    void Start()
    {
        vPlayer = GetComponent<VideoPlayer>();
    }

    void Update()
    {
        if (!vPlayer.isPlaying && !loading)
        {
            loading = true;
            SceneManager.LoadScene("StartScreen");
        }

        if (Input.GetButtonDown("Start") && !loading)
        {
            loading = true;
            SceneManager.LoadScene("StartScreen");
        }
    }
}
