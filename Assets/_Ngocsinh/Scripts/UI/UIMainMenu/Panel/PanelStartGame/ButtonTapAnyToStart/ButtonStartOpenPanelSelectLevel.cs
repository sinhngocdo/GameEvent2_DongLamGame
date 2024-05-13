using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Ngocsinh.Scripts.UI.UIMainMenu.Panel.PanelStartGame.ButtonTapAnyToStart
{
    public class ButtonStartOpenPanelSelectLevel : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private PanelSelectLevel.PanelSelectLevel panelSelectLevel;

        private void Reset()
        {
            _button = GetComponent<Button>();
            panelSelectLevel = FindObjectOfType<PanelSelectLevel.PanelSelectLevel>();
        }

        private void Start()
        {
            _button.onClick.AddListener(() =>
            {
                panelSelectLevel.Enable();
            });
        }
    }
}
