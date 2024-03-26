using DG.Tweening;
using UnityEngine;

namespace Game.Grid
{
    public class GridViewAnimation : MonoBehaviour
    {
        [Header("Animation settings")] 
        [SerializeField] private Transform _target;
        [SerializeField] private float _startScale;
        [SerializeField] private Ease _ease;
        [SerializeField] private float _duration;
        
        public void PlayAppearAnimation()
        {
            _target.localScale = Vector3.one * _startScale;
            _target
                .DOScale(1f, _duration)
                .SetEase(_ease);
        }
    }
}