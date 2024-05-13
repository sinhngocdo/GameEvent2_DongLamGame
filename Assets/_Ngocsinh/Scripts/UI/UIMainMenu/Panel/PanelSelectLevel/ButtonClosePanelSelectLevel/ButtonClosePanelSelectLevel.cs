using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Ngocsinh.Scripts.UI.UIMainMenu.Panel.PanelSelectLevel.ButtonClosePanelSelectLevel
{
    public class ButtonClosePanelSelectLevel : MonoBehaviour
    {
        [SerializeField] private Button _button;
        
        [SerializeField] private PanelSelectLevel panelSelectLevel;

        private void Reset()
        {
            _button = GetComponent<Button>();
            panelSelectLevel = FindObjectOfType<PanelSelectLevel>();
        }

        private void Start()
        {
            _button.onClick.AddListener(() =>
            {
                panelSelectLevel.Disable();
            });
        }
    }
}
