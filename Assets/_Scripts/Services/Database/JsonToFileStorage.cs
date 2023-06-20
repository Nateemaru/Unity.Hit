using System;
using System.IO;
using UnityEngine;

namespace _Scripts.Services.Database
{
    public class JsonToFileStorage : IStorageService
    {
        public JsonToFileStorage()
        {
            
        }
        
        public void Save<TData>(string key, TData data, Action callback = null)
        {
            var path = BuildPath(key); 
            var json = JsonUtility.ToJson(data);
            
            try {
                File.WriteAllText(path, json);
            } catch (Exception e) {
                Debug.LogError(e);
                return;
            }
            callback?.Invoke();
        }

        public TData Load<TData>(string key)
        {
            var path = BuildPath(key);

            if (File.Exists(path))
            {
                var json = File.ReadAllText(path);
                var data = JsonUtility.FromJson<TData>(json);

                return data;
            }

            return default;
        }

        private string BuildPath(string key)
        {
            return Path.Combine(Application.persistentDataPath, key + ".json");
        }
    }
}