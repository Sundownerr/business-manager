using UnityEngine;

namespace Game
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private UpgradesData _upgradesData;
        [SerializeField] private IncomeTimeData _incomeTimeData;
        [SerializeField] private BusinessLevelData _businessLevelData;
        [SerializeField] private WalletData _walletData;
        [SerializeField] private WalletPresenter _walletPresenter;
        [SerializeField] private BusinessModel[] _businesses;
        [SerializeField] private UpgradeModel[] _upgrades;
        [SerializeField] private BusinessPresenter[] _businessPresenters;
        [SerializeField] private UpgradePresenter[] _upgradePresenters;
        private readonly Loader _loader = new();
        private readonly Saver _saver = new();

        private void Start()
        {
            foreach (var upgradePresenter in _upgradePresenters)
            {
                upgradePresenter.Activate();
            }

            Load();

            _walletPresenter.Activate();

            foreach (var business in _businesses)
            {
                ApplyLoadedDataTo(business);
            }

            foreach (var businessPresenter in _businessPresenters)
            {
                businessPresenter.Activate();
            }

            foreach (var upgrade in _upgrades)
            {
                ApplyLoadedDataTo(upgrade);
            }
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            if (!hasFocus)
            {
                Save();
            }
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            if (pauseStatus)
            {
                Save();
            }
        }

        private void OnApplicationQuit()
        {
            Save();
        }

        private void ApplyLoadedDataTo(UpgradeModel upgrade)
        {
            if (_upgradesData.IsPurchased(upgrade.Key))
            {
                upgrade.SetPurchased();
                return;
            }

            if (!_upgradesData.Have(upgrade.Key))
            {
                _upgradesData.Add(upgrade.Key);
            }
        }

        private void ApplyLoadedDataTo(BusinessModel business)
        {
            SetBusinessLevel(business);
            SetBusinessIncomeTime(business);
        }

        private void SetBusinessIncomeTime(BusinessModel business)
        {
            if (_incomeTimeData.Have(business.Key))
            {
                business.SetIncomeTime(_incomeTimeData.Of(business.Key));
                return;
            }

            if (!_incomeTimeData.Have(business.Key))
            {
                _incomeTimeData.Add(business.Key);
            }
        }

        private void SetBusinessLevel(BusinessModel business)
        {
            if (_businessLevelData.Have(business.Key))
            {
                business.SetLevel(_businessLevelData.LevelOf(business.Key));
                return;
            }

            _businessLevelData.Add(business.Key);

            for (var i = 0; i < business.InitialLevel; i++)
            {
                business.LevelUp();
            }
        }

        private void Load()
        {
            _loader.LoadInto(_incomeTimeData);
            _loader.LoadInto(_upgradesData);
            _loader.LoadInto(_businessLevelData);
            _loader.LoadInto(_walletData);
        }

        private void Save()
        {
            _saver.SaveFrom(_incomeTimeData);
            _saver.SaveFrom(_upgradesData);
            _saver.SaveFrom(_walletData);
            _saver.SaveFrom(_businessLevelData);
        }
    }
}