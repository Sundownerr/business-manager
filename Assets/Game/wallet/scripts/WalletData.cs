using UnityEngine;

namespace Game
{
    public class WalletData : MonoBehaviour, ISavedData
    {
        [SerializeField] private int _defaultMoney;
        private string _saveKey;
        public int Money { get; set; }

        public string SaveKey => "WalletData";

        public void SetDefault()
        {
            Money = _defaultMoney;
        }

        public string Serialize()
        {
            return Serializer.Serialize(Money);
        }

        public void Deserialize(string json)
        {
            Money = Serializer.Deserialize<int>(json);
        }
    }
}