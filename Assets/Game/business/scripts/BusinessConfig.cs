using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "SO/Business Config", fileName = "BusinessConfig", order = 0)]
    public class BusinessConfig : Config
    {
        [SerializeField] private float _incomeTime;
        [SerializeField] private int _basePrice;
        [SerializeField] private int _baseIncome;

        public float IncomeTime => _incomeTime;
        public int BasePrice => _basePrice;
        public int BaseIncome => _baseIncome;
    }
}