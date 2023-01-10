using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class BusinessLevelData : MonoBehaviour, ISavedData
    {
        private Dictionary<string, int> _levels;
        private string _saveKey;

        public string SaveKey => "BusinessLevelData";

        public void SetDefault()
        {
            _levels = new Dictionary<string, int>();
        }

        public int LevelOf(string key)
        {
            return _levels[key];
        }

        public void Add(string key)
        {
            _levels.Add(key, 0);
        }

        public bool Have(string key)
        {
            return _levels.ContainsKey(key);
        }

        public void Set(string key, int value)
        {
            _levels[key] = value;
        }

        public string Serialize()
        {
            return Serializer.Serialize(_levels);
        }

        public void Deserialize(string json)
        {
            _levels = Serializer.Deserialize<Dictionary<string, int>>(json);
        }
    }
}