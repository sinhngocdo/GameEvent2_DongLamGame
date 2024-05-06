using System;
using System.Collections;
using System.Collections.Generic;
using Ngocsinh.Observer;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] GameObject panelWin;
    [SerializeField] private GameObject panelLose;

    [SerializeField] CatAI cat1;
    [SerializeField] CatAI cat2;

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
        panelLose.SetActive(false);

        isMark = false;
    }

    private void Start()
    {
        this.RegisterListener(EventID.OnWinGame, (param) => OnWinGame());
        this.RegisterListener(EventID.OnLoseGame, (param) => OnLoseGame());
    }

    void OnWinGame()
    {
        panelWin.SetActive(true);
    }

    void OnLoseGame()
    {
        panelLose.SetActive(true);
    }

    public void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

}
