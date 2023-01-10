using UnityEngine;

namespace Game
{
    public class WalletPresenter : MonoBehaviour
    {
        [SerializeField] private WalletView _view;
        [SerializeField] private Wallet _model;

        public void Activate()
        {
            _model.Changed += ModelOnChanged;
            _view.SetMoneyValue(_model.Money);
        }

        private void ModelOnChanged()
        {
            _view.SetMoneyValue(_model.Money);
        }
    }
}