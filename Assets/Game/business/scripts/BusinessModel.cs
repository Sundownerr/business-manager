using System;
using System.Collections;
using UnityEngine;

namespace Game
{
    public class BusinessModel : MonoBehaviour
    {
        [SerializeField] private int _initialLevel;
        [SerializeField] private BusinessLevelData _businessLevelData;
        [SerializeField] private IncomeTimeData _incomeTimeData;
        [SerializeField] private BusinessConfig _config;
        [SerializeField] private Wallet _wallet;
        [SerializeField] private UpgradesData _upgradesData;
        [SerializeField] private UpgradeModel[] _upgrades;
        private float _incomeTime;

        public int InitialLevel => _initialLevel;
        public string Name => _config.Name.Value;
        public string Key => _config.Key;
        public int Level { get; private set; }
        public int LevelUpPrice => (Level + 1) * _config.BasePrice;
        public float IncomeProgress => _incomeTime / _config.IncomeTime;
        public event Action LeveledUp;
        
        public void StartGeneratingIncome()
        {
            StartCoroutine(GenerateIncome());
        }

        public void SetIncomeTime(float value)
        {
            _incomeTime = value;
        }

        public void SetLevel(int level)
        {
            for (var i = 0; i < level; i++)
            {
                LevelUp();
            }
        }

        private IEnumerator GenerateIncome()
        {
            while (true)
            {
                while (_incomeTime <= _config.IncomeTime)
                {
                    _incomeTime += Time.deltaTime;
                    _incomeTimeData.Set(Key, _incomeTime);
                    yield return null;
                }

                _incomeTime = 0;
                _wallet.Add(Income());
            }
        }

        public int Income()
        {
            var upgradeModifiers = 0f;

            foreach (var upgrade in _upgrades)
            {
                if (_upgradesData.IsPurchased(upgrade.Key))
                {
                    upgradeModifiers += upgrade.Modifier;
                }
            }

            return (int) (Level * _config.BaseIncome * (1 + upgradeModifiers));
        }

        public bool CanBuyLevelUp()
        {
            return _wallet.Have(LevelUpPrice);
        }

        public void LevelUp()
        {
            Level++;
            LeveledUp?.Invoke();

            _businessLevelData.Set(Key, Level);
        }

        public void BuyLevelUp()
        {
            _wallet.Spend(LevelUpPrice);
            LevelUp();
        }
    }
}