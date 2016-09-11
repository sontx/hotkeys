namespace Plugin
{
    public interface IPlugin
    {
        void Load(string workingDir);
        void Unload();
    }
}
