using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Pool.Abstraction
{
    public abstract class ObjectPool<TPoolElement> : MonoBehaviour 
        where TPoolElement : Component, IPoolElement
    {
        [Header("Settings")]
        [SerializeField] private Transform _holder;

        [SerializeField] private TPoolElement _poolElement;
        [SerializeField] private uint _prewarmCount;

        private readonly List<TPoolElement> _poolElements = new List<TPoolElement>();
        
        private void Awake()
        {
            for (var i = 0; i < _prewarmCount; i++)
            {
                _poolElements.Add(CreateElement());
            }
        }

        public TPoolElement GetElement()
        {
            if (TryGetElement(out var result))
                return result;

            result = CreateElement();
            _poolElements.Add(result);
            
            return result;
        }

        public void ReturnElement(TPoolElement element)
        {
            element.transform.SetParent(_holder);
            element.gameObject.SetActive(false);
        }
        
        private bool TryGetElement(out TPoolElement element)
        {
            element = _poolElements.FirstOrDefault(e => e.gameObject.activeSelf == false);

            return element != null;
        }

        private TPoolElement CreateElement()
        {
            var item = Instantiate(_poolElement, _holder);
            item.gameObject.SetActive(false);

            return item;
        }
    }
}