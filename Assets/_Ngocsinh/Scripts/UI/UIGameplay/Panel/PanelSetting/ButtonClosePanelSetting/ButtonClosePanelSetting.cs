using UnityEngine;
using UnityEngine.UI;

namespace _Ngocsinh.Scripts.UI.UIGameplay.Panel.PanelSetting.ButtonClosePanelSetting
{
    public class ButtonClosePanelSetting : MonoBehaviour
    {
        [SerializeField] private Button _button;
        
        [SerializeField] private PanelSetting _panelSetting;

        private void Reset()
        {
            _button = GetComponent<Button>();
            _panelSetting = FindObjectOfType<PanelSetting>();
        }

        private void Start()
        {
            _button.onClick.AddListener(() =>
            {
                _panelSetting.Disable();
            });
        }
    }
}
