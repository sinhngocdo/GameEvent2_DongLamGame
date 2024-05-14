using System;
using Ngocsinh.Observer;
using UnityEngine;

namespace _Ngocsinh.Scripts.Manage.LevelManage
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private LevelObject[] levelObjects;

        [HideInInspector] public static int currentLevel;
        [HideInInspector] public static int unlockedLevels;


        private void Start()
        {
            unlockedLevels = PlayerPrefs.GetInt("unlockedLevels", 0);
            UpdateLevelView();
            
            this.RegisterListener(EventID.OnWinGame, (param) => OnWinGame());
        }

        private void UpdateLevelView()
        {
            for (int i = 0; i < levelObjects.Length; i++)
            {
                if (i <= unlockedLevels)
                {
                    levelObjects[i]._button.interactable = true;
                }
            }
        }

        void OnWinGame()
        {
            if ((currentLevel-1) == unlockedLevels)
            {
                unlockedLevels++;
                PlayerPrefs.SetInt("unlockedLevels", unlockedLevels);
            }
            
            UpdateLevelView();
        }
    }
}
