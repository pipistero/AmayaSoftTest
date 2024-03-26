using System;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Card.View
{
    public class CardViewAnimation : MonoBehaviour
    {
        [Header("Base settings")] 
        [SerializeField] private Transform _target;
        
        [Header("Correct animation settings")] 
        [SerializeField] private float _correctAnimationEndValue;
        [SerializeField] private float _correctAnimationDuration;
        [SerializeField] private Ease _correctAnimationEase;
        
        [Header("Incorrect animation settings")]
        [SerializeField] private float _incorrectAnimationEndValue;
        [SerializeField] private float _incorrectAnimationDuration;
        [SerializeField] private Ease _incorrectAnimationEase;

        private Tween _correctAnimationTween;
        private Tween _incorrectAnimationTween;
        
        public async Task PlayCorrectAnimation()
        {
            _correctAnimationTween?.Kill();
            _correctAnimationTween = _target
                .DOLocalMoveX(_correctAnimationEndValue, _correctAnimationDuration)
                .SetEase(_correctAnimationEase);

            await Delay(_correctAnimationDuration);
            
            _target.localPosition = Vector3.zero;
        }

        public async Task PlayIncorrectAnimation()
        {
            _incorrectAnimationTween?.Kill();
            _incorrectAnimationTween = _target
                .DOLocalMoveX(_incorrectAnimationEndValue, _incorrectAnimationDuration)
                .SetEase(_incorrectAnimationEase);
            
            await Delay(_incorrectAnimationDuration);
            
            _target.localPosition = Vector3.zero;
        }

        private Task Delay(float delay)
        {
            return Task.Delay(TimeSpan.FromSeconds(delay));
        }
    }
}