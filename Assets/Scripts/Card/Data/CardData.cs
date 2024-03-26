using System;
using UnityEngine;

namespace Card.Data
{
    [Serializable]
    public class CardData
    {
        [SerializeField] private string _identifier;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private float _rotation;

        public string Identifier => _identifier;
        public Sprite Sprite => _sprite;
        public float Rotation => _rotation;
    }
}