using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    [SerializeField] private GameObject startEfect;
    [SerializeField] private AudioClip music;
    [SerializeField] private AudioClip startSong;
    private AudioSource source;
    private bool load = false;

    void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = music;
        source.PlayOneShot(source.clip);
    }

    void Update()
    {
        if (Input.GetButtonDown("Start") && !load)
        {
            StartCoroutine(Efect());
        }

        if (!source.isPlaying || Input.GetKey(KeyCode.Tab) && !load)
        {
            StartCoroutine(LoadOP());
        }
    }

    IEnumerator Efect()
    {
        load = true;
        source.clip = startSong;
        source.PlayOneShot(startSong);
        for(int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.05f);
            startEfect.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(0.05f);
            startEfect.GetComponent<SpriteRenderer>().enabled = false;
        }
        
        AsyncOperation loading = SceneManager.LoadSceneAsync("StageSelect");

        while (!loading.isDone)
        {
            yield return null;
        }
    }

    IEnumerator LoadOP()
    {
        load = true;
        AsyncOperation loading = SceneManager.LoadSceneAsync("GameOpening");

        while (!loading.isDone)
        {
            yield return null;
        }
    }
}
