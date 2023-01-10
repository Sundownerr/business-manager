using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "SO/Name", fileName = "Name", order = 0)]
    public class Name : ScriptableObject
    {
        [SerializeField] private string _value;
        public string Value => _value;
    }
}