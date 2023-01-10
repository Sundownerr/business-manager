using System;
using UnityEngine;

namespace Game
{
    public class UpgradeModel : MonoBehaviour
    {
        [SerializeField] private UpgradesData _upgradesData;
        [SerializeField] private UpgradeConfig _config;
        [SerializeField] private Wallet _wallet;

        public float Modifier => _config.Modifier;
        public string Name => _config.Name.Value;
        public string Key => _config.Key;
        public int Price => _config.Price;

        public event Action Purchased;

        public void SetPurchased()
        {
            Purchased?.Invoke();
        }

        public void Buy()
        {
            _wallet.Spend(Price);
            _upgradesData.Set(Key, true);
            SetPurchased();
        }

        public bool CanBuy()
        {
            return _wallet.Have(_config.Price) && !_upgradesData.IsPurchased(Key);
        }
    }
}