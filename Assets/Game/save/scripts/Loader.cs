using UnityEngine;

namespace Game
{
    public class Loader
    {
        public void LoadInto(ISavedData data)
        {
            var existingData = PlayerPrefs.GetString(data.SaveKey);

            if (string.IsNullOrEmpty(existingData))
            {
                data.SetDefault();

#if UNITY_EDITOR
                Debug.LogWarning($"{data.SaveKey} not found, created: {data.Serialize()}");
#endif

                return;
            }

            data.Deserialize(existingData);
#if UNITY_EDITOR
            Debug.Log($"Loaded {data.SaveKey}: {existingData}");
#endif
        }
    }
}