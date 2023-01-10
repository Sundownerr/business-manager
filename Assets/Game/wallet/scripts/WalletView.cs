using TMPro;
using UnityEngine;

namespace Game
{
    public class WalletView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _moneyValue;

        public void SetMoneyValue(int value)
        {
            _moneyValue.SetText($"{value}$");
        }
    }
}