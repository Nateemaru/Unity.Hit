using _Scripts.SO;

namespace _Scripts.Services.Database
{
    public interface IDataReader
    {
        public TrackableValue<T> GetData<T>(string key);
        public void SaveDataChanges();
    }
}