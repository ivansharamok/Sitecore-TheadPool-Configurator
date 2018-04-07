namespace Sitecore.ThreadPool.Configurator.Pipelines.Initialize
{
    using System;
    using System.Xml;
    using Sitecore.Abstractions;
    using Sitecore.Pipelines;
    using Sitecore.Reflection;
    using Sitecore.ThreadPool.Configurator.Core.Interfaces;
    using Sitecore.ThreadPool.Configurator.Infrastructure;

    public class ConfigureProcessModelThreads : IInitializable
    {
        private int minWorkerThreadsPerCore;
        private int maxWorkerThreadsPerCore;
        private int minIOThreadsPerCore;
        private int maxIOThreadsPerCore;
        protected readonly BaseLog Log;
        protected IConfigReader<XmlNode> ConfigSection;

        public ConfigureProcessModelThreads(BaseLog log)
        {
            Log = log;
        }
        public bool AssignProperties => false;

        public void Initialize(XmlNode configNode)
        {
            ConfigSection = new XmlConfigReader(configNode);
            maxWorkerThreadsPerCore = ConfigSection.GetIntSetting("maxWorkerThreadsPerCore");
            minWorkerThreadsPerCore = ConfigSection.GetIntSetting("minWorkerThreadsPerCore");
            maxIOThreadsPerCore = ConfigSection.GetIntSetting("maxIoThreadsPerCore");
            minIOThreadsPerCore = ConfigSection.GetIntSetting("minIoThreadsPerCore");
        }

        public void Process(PipelineArgs args)
        {
            LogTheadPoolConfiguration(args, "Default ThreadPool configuration");
            if (0 != MinWorkerThreads && 0 != MinIOThreads)
            {
                ApplicationThreadPoolConfigurator.SetMinThreads(MinWorkerThreads, MinIOThreads);
            }
            if (0 != MaxWorkerThreads && 0 != MaxIOThreads)
            {
                ApplicationThreadPoolConfigurator.SetMaxThreads(MaxWorkerThreads, MaxIOThreads);
            }
            LogTheadPoolConfiguration(args, "New TreadPool configuration");
        }

        private void LogTheadPoolConfiguration(PipelineArgs args, string header)
        {
            Diagnostics.Assert.ArgumentNotNull(args, "args");
            Diagnostics.Assert.ArgumentNotNull(header, "header");

            int minWorkerThreads, minIoThreads, maxWorkerThreads, maxIoThreads;
            ApplicationThreadPoolConfigurator.GetMinThreads(out minWorkerThreads, out minIoThreads);
            ApplicationThreadPoolConfigurator.GetMaxThreads(out maxWorkerThreads, out maxIoThreads);

            var message = new System.Text.StringBuilder()
                .AppendLine($"{this.GetType().ToString()}: {header}")
                .AppendLine("Processor count: " + ProcessorCount)
                .AppendLine("minWorkerThreads: " + minWorkerThreads)
                .AppendLine("minIOThreads: " + minIoThreads)
                .AppendLine("maxWorkerThreads: " + maxWorkerThreads)
                .AppendLine("maxIOThreads: " + maxIoThreads).ToString();
            Log.Info(message, this);
        }

        protected int MinWorkerThreads => minWorkerThreadsPerCore * ProcessorCount;
        protected int MaxWorkerThreads => maxWorkerThreadsPerCore * ProcessorCount;
        protected int MinIOThreads => minIOThreadsPerCore * ProcessorCount;
        protected int MaxIOThreads => maxIOThreadsPerCore * ProcessorCount;
        private int ProcessorCount => Environment.ProcessorCount;
    }
}
