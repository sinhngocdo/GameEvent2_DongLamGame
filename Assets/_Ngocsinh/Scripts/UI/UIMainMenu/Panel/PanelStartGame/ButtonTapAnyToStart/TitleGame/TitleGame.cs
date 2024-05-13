using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace _Ngocsinh.Scripts.UI.UIMainMenu.Panel.PanelStartGame.ButtonTapAnyToStart.TitleGame
{
    public class TitleGame : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        [SerializeField] private float blinkDuration;
        [SerializeField] private float _value;


        private void Reset()
        {
            _text = GetComponent<TMP_Text>();
        }

        private void Start()
        {
            StartBlink();
        }

        private void StartBlink()
        {
            _text.DOFade(_value/255, blinkDuration).SetLoops(-1, LoopType.Yoyo);
        }
    }
}
