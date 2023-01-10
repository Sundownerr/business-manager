using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class UpgradesData : MonoBehaviour, ISavedData
    {
        private string _saveKey;
        private Dictionary<string, bool> _upgradesPurchases;

        public string SaveKey => "PurchasesData";

        public void SetDefault()
        {
            _upgradesPurchases = new Dictionary<string, bool>();
        }

        public string Serialize()
        {
            return Serializer.Serialize(_upgradesPurchases);
        }

        public void Deserialize(string json)
        {
            _upgradesPurchases = Serializer.Deserialize<Dictionary<string, bool>>(json);
        }

        public void Add(string key)
        {
            _upgradesPurchases.Add(key, false);
        }

        public void Set(string key, bool value)
        {
            _upgradesPurchases[key] = value;
        }

        public bool Have(string key)
        {
            return _upgradesPurchases.ContainsKey(key);
        }

        public bool IsPurchased(string key)
        {
            if (_upgradesPurchases.TryGetValue(key, out var purchased))
            {
                return purchased;
            }

            return false;
        }
    }
}