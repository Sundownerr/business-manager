using UnityEngine;

namespace Game
{
    public class UpgradePresenter : MonoBehaviour
    {
        [SerializeField] private UpgradeView _view;
        [SerializeField] private UpgradeModel _model;

        public void Activate()
        {
            _model.Purchased += ModelOnPurchased;

            _view.SetTitle(_model.Name)
                .SetModifier(_model.Modifier)
                .SetPrice(_model.Price);

            _view.Pressed.AddListener(() =>
            {
                if (!_model.CanBuy())
                {
                    return;
                }

                _model.Buy();
            });
        }

        private void ModelOnPurchased()
        {
            _model.Purchased -= ModelOnPurchased;
            _view.SetPurchased();
        }
    }
}