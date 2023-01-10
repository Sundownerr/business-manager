using UnityEngine;

namespace Game
{
    public class BusinessPresenter : MonoBehaviour
    {
        [SerializeField] private BusinessView _view;
        [SerializeField] private BusinessModel _model;
        [SerializeField] private UpgradeModel[] _upgradeModels;
        private bool _canUpdate;

        private void Update()
        {
            if (!_canUpdate)
            {
                return;
            }

            _view.SetIncomeProgress(_model.IncomeProgress);
        }

        public void Activate()
        {
            _view.SetTitle(_model.Name);

            UpdateView();

            _model.StartGeneratingIncome();
            _canUpdate = true;

            _model.LeveledUp += ModelOnLeveledUp;

            foreach (var upgradeModel in _upgradeModels)
            {
                upgradeModel.Purchased += UpgradeModelOnPurchased;
            }
        }

        private void UpgradeModelOnPurchased()
        {
            UpdateView();
        }

        private void ModelOnLeveledUp()
        {
            UpdateView();
        }

        private void UpdateView()
        {
            _view.SetLevel(_model.Level)
                .SetPrice(_model.LevelUpPrice)
                .SetIncome(_model.Income());
        }

        public void LevelUp()
        {
            if (!_model.CanBuyLevelUp())
            {
                return;
            }

            _model.BuyLevelUp();
            UpdateView();
        }
    }
}