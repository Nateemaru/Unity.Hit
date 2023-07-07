using System.Collections.Generic;
using _Scripts.Services.EventBusService;
using _Scripts.Services.EventBusService.EventsInterfaces;
using UnityEngine;
using Zenject;

namespace _Scripts.Services.Database
{
    public class DataReader : IDataReader, IInitializable
    {
        private IStorageService _storageService;

        public DataReader(IStorageService storageService)
        {
            _storageService = storageService;
        }

        public void Initialize()
        {
        }

        public void SaveData<TData>(string key, TData data)
        {
            _storageService.Save(key, data);
            EventBus.RaiseEvent<IStorageDataUpdatedSubscriber>(item => item.OnDataUpdated());
        }
        
        public void SaveArrayData<TData>(string key, TData[] data)
        {
            _storageService.SaveArray(key, data);
            EventBus.RaiseEvent<IStorageDataUpdatedSubscriber>(item => item.OnDataUpdated());
        }
        

        public TData GetData<TData>(string key) where TData : class
        {
            var data = _storageService.Load<TData>(key);
            return data;
        }
        
        public TData[] GetArrayData<TData>(string key) where TData : class
        {
            var data = _storageService.LoadArray<TData>(key);
            return data;
        }
    }
}