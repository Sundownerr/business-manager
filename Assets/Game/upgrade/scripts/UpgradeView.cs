using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class UpgradeView : MonoBehaviour
    {
        [SerializeField] private string _purchasedText;
        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _modifierValue;
        [SerializeField] private TMP_Text _priceValue;
        [SerializeField] private TMP_Text _title;

        public Button.ButtonClickedEvent Pressed => _button.onClick;

        public UpgradeView SetModifier(float value)
        {
            _modifierValue.SetText($"+{(value * 100).ToString(CultureInfo.InvariantCulture)}%");
            return this;
        }

        public UpgradeView SetPrice(int value)
        {
            _priceValue.SetText($"{value.ToString()}$");
            return this;
        }

        public UpgradeView SetTitle(string value)
        {
            _title.SetText(value);
            return this;
        }

        public void SetPurchased()
        {
            _priceValue.SetText(_purchasedText);
        }
    }
}