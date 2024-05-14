using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Ngocsinh.Observer;
using UnityEngine;
using UnityEngine.UI;

namespace _Ngocsinh.Scripts.UI.UIGameplay.Panel.PanelWinGame
{
    public class PanelWinGame : MonoBehaviour
    {
        #region Code
        private TweenerCore<Vector2, Vector2, VectorOptions> _tweenerCore;
        private Vector2 initPosition;

        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private Image _image;
        [SerializeField] private float _fadeValue;
        


        private void Reset()
        {
            _rectTransform = GetComponent<RectTransform>();
            _image = GetComponent<Image>();
        }

        private void Start()
        {
            initPosition = _rectTransform.anchoredPosition;
            this.RegisterListener(EventID.OnWinGame, (param) => OnWinGame());
        }

        public void Enable()
        {
            if (_tweenerCore != null)
            {
                _tweenerCore.Kill();
            }

            _tweenerCore = _rectTransform.DOAnchorPos(Vector2.zero, .3f).OnComplete(() =>
            {
                _image.DOFade(_fadeValue / 255f, .3f);
                _tweenerCore = null;
            });
        }

        public void Disable()
        {
            if (_tweenerCore != null)
            {
                _tweenerCore.Kill();
            }

            _image.DOFade(0f, .3f).OnComplete(() =>
            {
                _tweenerCore =_rectTransform.DOAnchorPos(initPosition, .3f).OnComplete(() => { _tweenerCore = null; });
            });
            
            
        }

        void OnWinGame()
        {
            this.Enable();
        }

        #endregion
    }
}
