using System;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Window
{
    public class LoadingWindow : Window
    {
        [Header("Animations")] 
        [SerializeField] private Image _blocker;
        [SerializeField] private float _fadeDuration;

        private Tween _fadeTween;
        
        public override async Task Open()
        {
            _content.SetActive(true);

            await DoFade(1f);
        }

        public override async Task Close()
        {
            await DoFade(0f);
            
            _content.SetActive(false);
        }

        private async Task DoFade(float endValue)
        {
            _fadeTween?.Kill();
            _fadeTween = _blocker.DOFade(endValue, _fadeDuration);
            
            await Task.Delay(TimeSpan.FromSeconds(_fadeDuration));
        }
    }
}