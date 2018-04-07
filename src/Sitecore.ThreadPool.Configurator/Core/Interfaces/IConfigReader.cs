namespace Sitecore.ThreadPool.Configurator.Core.Interfaces
{
    public interface IConfigReader<T>
    {
        T Configuration { get; }
        int GetIntSetting(string setting);
        string GetStringSetting(string setting);
    }
}
