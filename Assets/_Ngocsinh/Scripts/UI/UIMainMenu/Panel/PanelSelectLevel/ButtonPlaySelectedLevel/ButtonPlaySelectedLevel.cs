using System;
using _Ngocsinh.Scripts.Manage.LevelManage;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Ngocsinh.Scripts.UI.UIMainMenu.Panel.PanelSelectLevel.ButtonPlaySelectedLevel
{
    public class ButtonPlaySelectedLevel : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private int _levelNumber;


        private void Reset()
        {
            _button = GetComponent<Button>();
            _text = GetComponentInChildren<TMP_Text>();
        }

        private void Start()
        {
            _text.text = _levelNumber.ToString();
            
            
            _button.onClick.AddListener(() =>
            {
                OnStartLevel(_levelNumber);
            });
        }

        void OnStartLevel(int levelNum)
        {
            LevelManager.currentLevel = levelNum;
            SceneManager.LoadScene("Level " + levelNum);
        }
    }
}
