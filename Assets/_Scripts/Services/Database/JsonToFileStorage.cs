using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace _Scripts.Services.Database
{
    public class JsonToFileStorage : IStorageService
    {
        public void Save<TData>(string key, TData data, Action callback = null)
        {
            var path = BuildPath(key); 
            
            if(File.Exists(path))
                File.Delete(path);
            
            //var json = JsonConvert.SerializeObject(data, Formatting.Indented);
            var json = JsonUtility.ToJson(data);
            
            try {
                File.WriteAllText(path, json);
            } catch (Exception e) {
                Debug.LogError(e);
                return;
            }
            callback?.Invoke();
        }
        
        public void SaveArray<TData>(string key, TData[] data, Action callback = null)
        {
            var path = BuildPath(key); 
            
            if(File.Exists(path))
                File.Delete(path);
            
            Wrapper<TData> wrapper = new Wrapper<TData>();
            wrapper.Items = data;
            
            //var json = JsonConvert.SerializeObject(wrapper, Formatting.Indented);
            var json = JsonUtility.ToJson(wrapper);
            
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
                //var data = JsonConvert.DeserializeObject<TData>(json);
                var data = JsonUtility.FromJson<TData>(json);

                return data;
            }

            return default;
        }

        public TData[] LoadArray<TData>(string key)
        {
            var path = BuildPath(key);

            if (File.Exists(path))
            {
                var json = File.ReadAllText(path);
                //var data = JsonConvert.DeserializeObject<Wrapper<TData>>(json);
                var data = JsonUtility.FromJson<Wrapper<TData>>(json);

                return data.Items;
            }

            return default;
        }

        private string BuildPath(string key) => Path.Combine(Application.persistentDataPath, key + ".json");
        
        [Serializable]
        private class Wrapper<T>
        {
            public T[] Items;
        }
    }
}