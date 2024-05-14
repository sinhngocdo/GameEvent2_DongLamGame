using _Ngocsinh.Scripts.Manage.LevelManage;
using _Ngocsinh.Scripts.UI.UIGameplay.Panel.PanelWinGame;
using Ngocsinh.Observer;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI.UIWinLose.WinBtn
{
    public class WinBtn : MonoBehaviour
    {
        [SerializeField] private Button button;

        [SerializeField] private PanelWinGame _panelWinGame;

        private void Reset()
        {
            button = GetComponent<Button>();
            _panelWinGame = FindObjectOfType<PanelWinGame>();
        }

        private void Start()
        {
            button.onClick.AddListener(() =>
            {
                this.PostEvent(EventID.OnWinGame);
                _panelWinGame.Enable();
            });
        }
    }
}
