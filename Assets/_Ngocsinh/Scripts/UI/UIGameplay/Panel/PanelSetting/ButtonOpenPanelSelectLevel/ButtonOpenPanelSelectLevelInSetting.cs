using _Ngocsinh.Scripts.UI.UIMainMenu.Panel.PanelSelectLevel;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace _Ngocsinh.Scripts.UI.UIGameplay.Panel.PanelSetting.ButtonOpenPanelSelectLevel
{
    public class ButtonOpenPanelSelectLevelInSetting : MonoBehaviour
    {
        [SerializeField] private Button _button;

        [SerializeField] private PanelSetting _panelSetting;
        [SerializeField] private PanelSelectLevel panelSelectLevel;

        private void Reset()
        {
            _button = GetComponent<Button>();
            panelSelectLevel = FindObjectOfType<PanelSelectLevel>();
            _panelSetting = FindObjectOfType<PanelSetting>();
        }

        private void Start()
        {
            _button.onClick.AddListener(() =>
            {
                _panelSetting.Disable();
                panelSelectLevel.Enable();
            });
        }
    }
}
