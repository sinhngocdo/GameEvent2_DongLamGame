using _Ngocsinh.Scripts.UI.UIMainMenu.Panel.PanelSelectLevel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Ngocsinh.Scripts.UI.UIGameplay.Panel.PanelLoseGame.ButtonOpenPanelSelectLevel
{
    public class ButtonOpenPanelSelectLevelInLoseGame : MonoBehaviour
    {
        [SerializeField] private Button _button;

        [SerializeField] private PanelLoseGame panelLoseGame;
        [SerializeField] private PanelSelectLevel panelSelectLevel;

        private void Reset()
        {
            _button = GetComponent<Button>();
            panelSelectLevel = FindObjectOfType<PanelSelectLevel>();
            panelLoseGame = FindObjectOfType<PanelLoseGame>();
        }

        private void Start()
        {
            _button.onClick.AddListener(() =>
            {
                panelLoseGame.Disable();
                panelSelectLevel.Enable();
            });
        }
    }
}
