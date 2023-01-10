using UnityEngine;

namespace Game
{
    public class Saver 
    {
        public void SaveFrom(ISavedData data)
        {
            var savedDataJson = data.Serialize();
            PlayerPrefs.SetString(data.SaveKey, savedDataJson);
#if UNITY_EDITOR
            Debug.Log($"Saved {data.SaveKey}: {savedDataJson}");
#endif
        }
    }
}