using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class BusinessView : MonoBehaviour
    {
        [SerializeField] private BusinessPresenter _presenter;
        [SerializeField] private Button _levelUpButton;
        [SerializeField] private TMP_Text _levelValue;
        [SerializeField] private TMP_Text _priceValue;
        [SerializeField] private TMP_Text _incomeValue;
        [SerializeField] private TMP_Text _title;
        [SerializeField] private Image _incomeProgress;

        private void Start()
        {
            _levelUpButton.onClick.AddListener(() => { _presenter.LevelUp(); });
        }

        public BusinessView SetLevel(int value)
        {
            _levelValue.SetText(value.ToString());
            return this;
        }

        public BusinessView SetPrice(int value)
        {
            _priceValue.SetText($"{value.ToString()}$");
            return this;
        }

        public BusinessView SetIncome(int value)
        {
            _incomeValue.SetText($"{value.ToString()}$");
            return this;
        }


        public BusinessView SetTitle(string value)
        {
            _title.SetText(value);
            return this;
        }

        public void SetIncomeProgress(float value)
        {
            _incomeProgress.fillAmount = value;
        }
    }
}