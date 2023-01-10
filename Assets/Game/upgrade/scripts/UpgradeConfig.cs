using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "SO/Upgrade Config", fileName = "UpgradeConfig", order = 0)]
    public class UpgradeConfig : Config
    {
        [SerializeField] private int _price;
        [SerializeField] private float _modifier;

        public int Price => _price;
        public float Modifier => _modifier;
    }
}