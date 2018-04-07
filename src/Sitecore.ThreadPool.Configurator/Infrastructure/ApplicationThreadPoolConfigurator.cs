namespace Sitecore.ThreadPool.Configurator.Infrastructure
{
    using System.Threading;

    public static class ApplicationThreadPoolConfigurator
    {
        public static void SetMaxThreads(int workerThreads, int ioThreads)
        {
            ThreadPool.SetMaxThreads(workerThreads, ioThreads);
        }

        public static void SetMinThreads(int workerThreads, int ioThreads)
        {
            ThreadPool.SetMinThreads(workerThreads, ioThreads);
        }

        public static void GetMinThreads(out int workerThreads, out int ioThreads)
        {
            ThreadPool.GetMinThreads(out workerThreads, out ioThreads);
        }

        public static void GetMaxThreads(out int workerThreads, out int ioThreads)
        {
            ThreadPool.GetMaxThreads(out workerThreads, out ioThreads);
        }
    }
}
