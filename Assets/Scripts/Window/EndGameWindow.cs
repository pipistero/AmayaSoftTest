using System;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Window
{
    public class EndGameWindow : Window
    {
        #region Consts

        private readonly Color ClearColor = new Color(.15f, .15f, .15f, 0f);

        #endregion
        
        public event Action Restart;
        
        [Header("Animations")] 
        [SerializeField] private Image _blocker;
        [SerializeField] private float _endFadeValue;
        [SerializeField] private float _fadeDuration;

        [Header("Buttons")] 
        [SerializeField] private Button _restartButton;
        
        private Tween _fadeTween;

        private void Start()
        {
            _restartButton.onClick.AddListener(OnRestartButtonClick);
        }

        public override async Task Open()
        {
            _content.SetActive(true);
            
            _fadeTween?.Kill();
            _fadeTween = _blocker.DOFade(_endFadeValue, _fadeDuration);
        }

        public override async Task Close()
        {
            _blocker.color = ClearColor;
            _content.SetActive(false);
        }

        private void OnRestartButtonClick()
        {
            Restart?.Invoke();
        }
        
        private void OnDestroy()
        {
            _restartButton.onClick.RemoveAllListeners();
        }
    }
}