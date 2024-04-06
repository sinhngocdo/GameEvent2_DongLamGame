using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] GameObject panelWin;

    [SerializeField] CatHandle cat1;
    [SerializeField] CatHandle cat2;

    [SerializeField] bool isMark = false;


    Vector3 posStartSpawn;
    Vector3 posEndSpawn;

    public bool IsMark { get => isMark; set => isMark = value; }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        panelWin.SetActive(false);

        isMark = false;
    }

    private void Update()
    {
        if(cat1.IsShoot() && cat2.IsShoot())
        {
            Debug.Log("Game Win");
            //panelWin.SetActive(true);
            isMark = true;
        }
    }

    public void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

}
