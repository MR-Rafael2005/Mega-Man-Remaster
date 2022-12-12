using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Experimental.Rendering.Universal;

public class StageSelectManager : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField] private GameObject selectEfect;
    [SerializeField] private Transform[] positions;
    private bool load = false;
    public string[] stages;

    public int stageNumber = 0;

    void Start()
    {
        gameManager = GameManager.gameManager;
        StartCoroutine(Efect());
    }

    void Update()
    {
        if (!gameManager.stagesFinish.Contains(stageNumber))
        {
            selectEfect.GetComponent<SpriteRenderer>().color = Color.white;
            selectEfect.GetComponent<Light2D>().intensity = 0.4f;
        }
        else
        {
            selectEfect.GetComponent<SpriteRenderer>().color = new Vector4(0.45f, 0.45f, 0.45f, 1);
            selectEfect.GetComponent<Light2D>().intensity = 0f;
        }

        selectEfect.transform.position = positions[stageNumber].position;

        if (Input.GetButtonDown("Horizontal") && !load)
        {
            float axis = Input.GetAxisRaw("Horizontal");

            if(axis < 0)
            {
                if(stageNumber == 0)
                {
                    stageNumber = positions.Length - 1;
                }
                else
                {
                    stageNumber--;
                }
            }
            else
            {
                if(stageNumber == positions.Length - 1)
                {
                    stageNumber = 0;
                }
                else
                {
                    stageNumber++;
                }
            }

           // Debug.Log(stageNumber);
        }

        if(Input.GetButtonDown("Start") && !load)
        {
            //StartCoroutine(LoadStage());
            //Debug.Log(stages[stageNumber]);
            gameManager.AddFinishStage(stageNumber);
        }
    }

    IEnumerator Efect()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.05f);
            selectEfect.SetActive(false);
            yield return new WaitForSeconds(0.05f);
            selectEfect.SetActive(true);   
        }
    }

    IEnumerator LoadStage()
    {
        load = true;
        AsyncOperation loading = SceneManager.LoadSceneAsync(stages[stageNumber]);

        while (!loading.isDone)
        {
            yield return null;
        }
    }
}
