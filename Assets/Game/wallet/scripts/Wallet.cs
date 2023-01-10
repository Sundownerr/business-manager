using System;
using UnityEngine;

namespace Game
{
    public class Wallet : MonoBehaviour
    {
        [SerializeField] private WalletData _walletData;
        public int Money => _walletData.Money;
        public event Action Changed;

        public bool Have(int amount)
        {
            return _walletData.Money >= amount;
        }

        public void Spend(int value)
        {
            _walletData.Money -= value;
            Changed?.Invoke();
        }

        public void Add(int value)
        {
            _walletData.Money += value;
            Changed?.Invoke();
        }
    }
}