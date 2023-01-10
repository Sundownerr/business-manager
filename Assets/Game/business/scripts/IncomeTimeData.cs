using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class IncomeTimeData : MonoBehaviour, ISavedData
    {
        private Dictionary<string, float> _incomeTimes;
        private string _saveKey;

        public string SaveKey => "IncomeProgressData";

        public void Set(string key, float value)
        {
            _incomeTimes[key] = value;
        }

        public bool Have(string key)
        {
            return _incomeTimes.ContainsKey(key);
        }

        public void Add(string key)
        {
            _incomeTimes.Add(key, 0);
        }

        public float Of(string key)
        {
            return _incomeTimes[key];
        }
        
        public void SetDefault()
        {
            _incomeTimes = new Dictionary<string, float>();
        }

        public string Serialize()
        {
            return Serializer.Serialize(_incomeTimes);
        }

        public void Deserialize(string json)
        {
            _incomeTimes = Serializer.Deserialize<Dictionary<string, float>>(json);
        }
    }
}