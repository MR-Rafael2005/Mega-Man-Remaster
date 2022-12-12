using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /*
    Stages:
    =======
    
    1.CutMan;
    2.GutsMan;
    3.IceMan;
    4.BombMan;
    5.FireMan;
    6.ElecMan;
    
    Fortress:
    =========
    
    1.Yellow Devil;
    2.Clone;
    3.Bubble Robot;
    4.Willy;
    
     */

    public static GameManager gameManager;

    public List<int> stagesFinish = new List<int>();

    private void Awake()
    {
        if(gameManager == null)
        {
            gameManager = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameManager);
    }

    void Start()
    {
        
    }

    void Update()
    {
    }

    public void AddFinishStage(int stageValue)
    {
        if (!stagesFinish.Contains(stageValue))
        {
            stagesFinish.Add(stageValue);
        }
    }
}
