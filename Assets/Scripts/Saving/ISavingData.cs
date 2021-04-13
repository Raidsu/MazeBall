namespace Items
{
    public interface ISavingData<T>
    {
        void Save(T data, string path = null);
        T Load(string path = null);
    }
}