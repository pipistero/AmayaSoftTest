using DG.Tweening;
using UnityEngine;

namespace Game.Grid
{
    public class GridViewAnimation : MonoBehaviour
    {
        [Header("Animation settings")] 
        [SerializeField] private Transform _target;
        [SerializeField] private float _startYPosition;
        [SerializeField] private Ease _ease;
        [SerializeField] private float _duration;
        
        public void PlayAppearAnimation()
        {
            _target.localPosition = Vector3.up * _startYPosition;
            _target
                .DOLocalMoveY(0f, _duration)
                .SetEase(_ease);
        }
    }
}