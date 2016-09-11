namespace Plugin
{
    public interface IPlugin
    {
        void Install();
        void Uninstall();
        void Load(string workingDir);
        void Unload();
    }
}
