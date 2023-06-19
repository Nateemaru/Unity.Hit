using _Scripts.SO;

namespace _Scripts.Services.Database
{
    public interface IDataContainer
    {
        public TrackableValue<T> GetData<T>(string key);
        public void SaveDataChanges();
    }
}