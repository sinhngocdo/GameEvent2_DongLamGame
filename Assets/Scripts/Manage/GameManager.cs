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

    Vector3 posStartSpawn;
    Vector3 posEndSpawn;

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
    }

    private void Update()
    {
        if(cat1.IsShoot() && cat2.IsShoot())
        {
            Debug.Log("Game Win");
            //panelWin.SetActive(true);
            SpawnRope();

        }
    }

    private void SpawnRope()
    {
        posStartSpawn = cat1.transform.position;
        posEndSpawn = cat2.transform.position;


    }

    public void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

}
