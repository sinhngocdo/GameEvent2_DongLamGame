using _Ngocsinh.Scripts.UI.UIMainMenu.Panel.PanelSelectLevel;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace _Ngocsinh.Scripts.UI.UIGameplay.Panel.PanelWinGame.ButtonOpenPanelSelectLevel
{
    public class ButtonOpenPanelSelectLevelInWinGame : MonoBehaviour
    {
        [SerializeField] private Button _button;

        [SerializeField] private PanelWinGame _panelWinGame;
        [SerializeField] private PanelSelectLevel panelSelectLevel;

        private void Reset()
        {
            _button = GetComponent<Button>();
            panelSelectLevel = FindObjectOfType<PanelSelectLevel>();
            _panelWinGame = FindObjectOfType<PanelWinGame>();
        }

        private void Start()
        {
            _button.onClick.AddListener(() =>
            {
                _panelWinGame.Disable();
                panelSelectLevel.Enable();
            });
        }
    }
}
