namespace Game
{
    public interface ISavedData
    {
        string SaveKey { get; }
        void SetDefault();
        string Serialize();
        void Deserialize(string json);
    }
}