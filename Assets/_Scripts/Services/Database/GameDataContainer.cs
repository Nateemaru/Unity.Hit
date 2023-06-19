using System.Collections.Generic;

namespace _Scripts.Services.Database
{
    public class GameDataContainer : IDataContainer
    {
        private IStorageService _storageService;
        private Dictionary<string, ITrackableValue> _dataDictionary = new Dictionary<string,  ITrackableValue>();

        public GameDataContainer(IStorageService storageService)
        {
            _storageService = storageService;

            InitDataDictionary();
        }

        private void InitDataDictionary()
        {
        }

        public void SaveDataChanges()
        {
            foreach (var data in _dataDictionary)
                _storageService.Save(data.Key, data.Value);
        }

        public TrackableValue<TData> GetData<TData>(string key)
        {
            if (_dataDictionary.TryGetValue(key, out var data))
                return data as TrackableValue<TData>;

            return null;
        }
    }
}