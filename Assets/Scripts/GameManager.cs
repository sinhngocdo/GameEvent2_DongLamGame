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
            panelWin.SetActive(true);
        }
    }

    public void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

}
