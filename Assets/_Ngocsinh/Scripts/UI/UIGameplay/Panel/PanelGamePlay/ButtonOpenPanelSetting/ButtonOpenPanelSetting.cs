using UnityEngine;
using UnityEngine.UI;

namespace _Ngocsinh.Scripts.UI.UIGameplay.Panel.PanelGamePlay.ButtonOpenPanelSetting
{
    public class ButtonOpenPanelSetting : MonoBehaviour
    {
        [SerializeField] private Button _button;
        
        [SerializeField] private PanelSetting.PanelSetting _panelSetting;

        private void Reset()
        {
            _button = GetComponent<Button>();
            _panelSetting = FindObjectOfType<PanelSetting.PanelSetting>();
        }

        private void Start()
        {
            _button.onClick.AddListener(() =>
            {
                _panelSetting.Enable();
            });
        }
    }
}
