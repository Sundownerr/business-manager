using UnityEngine;

namespace Game
{
    public class Config : ScriptableObject
    {
        [SerializeField] private Name _name;
        [SerializeField] private string _key;

        public Name Name => _name;
        public string Key => _key;
    }
}