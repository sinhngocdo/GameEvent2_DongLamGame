using Ngocsinh.Observer;
using UnityEngine;
using UnityEngine.UI;

namespace UI.UIWinLose.WinBtn
{
    public class WinBtn : MonoBehaviour
    {
        [SerializeField] private Button button;

        private void Reset()
        {
            button = GetComponent<Button>();
        }

        private void Start()
        {
            button.onClick.AddListener(() => this.PostEvent(EventID.OnWinGame));
        }
    }
}
