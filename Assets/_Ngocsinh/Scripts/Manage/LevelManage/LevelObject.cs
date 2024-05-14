using System;
using _Ngocsinh.Scripts.UI.UIMainMenu.Panel.PanelSelectLevel.ButtonPlaySelectedLevel;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace _Ngocsinh.Scripts.Manage.LevelManage
{
    public class LevelObject : MonoBehaviour
    {
        public Button _button;
        [SerializeField] private ButtonPlaySelectedLevel _buttonLevel;
        [SerializeField] private Image[] _stars;


        private void Reset()
        {
            _button = GetComponent<Button>();
            _buttonLevel = GetComponent<ButtonPlaySelectedLevel>();
            _stars = GetComponentsInChildren<Image>();
        }
    }
}
