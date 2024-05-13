using _Ngocsinh.Scripts.UI.UIGameplay.Panel.PanelLoseGame;
using Ngocsinh.Observer;
using UnityEngine;
using UnityEngine.UI;

namespace UI.UIWinLose.LoseBtn
{
    public class LoseBtn : MonoBehaviour
    {
        [SerializeField] private Button button;

        [SerializeField] private PanelLoseGame _panelLoseGame;

        private void Reset()
        {
            button = GetComponent<Button>();
            _panelLoseGame = FindObjectOfType<PanelLoseGame>();
        }

        private void Start()
        {
            button.onClick.AddListener(() => _panelLoseGame.Enable());
        }
    }
}
