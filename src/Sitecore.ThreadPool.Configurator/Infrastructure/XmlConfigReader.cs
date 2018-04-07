namespace Sitecore.ThreadPool.Configurator.Infrastructure
{
    using System.Xml;
    using Sitecore.ThreadPool.Configurator.Core.Interfaces;
    using Sitecore.Xml;

    public class XmlConfigReader : IConfigReader<XmlNode>
    {
        private readonly XmlNode configuration;

        public XmlConfigReader()
        {
            var doc = new XmlDocument();
            doc.LoadXml("<configuration/>");
            configuration = doc.DocumentElement;
        }

        public XmlConfigReader(XmlNode configNode)
        {
            configuration = configNode;
        }

        public XmlNode Configuration {
            get => configuration;
        }

        public int GetIntSetting(string setting)
        {
            var node = XmlUtil.FindChildNode(setting, Configuration, false);
            int value;
            if (null != node)
            {
                if (!int.TryParse(node.InnerText, out value)) { value = 0; }
            }
            else
            {
                value = 0;
            }
            return value;
        }

        public string GetStringSetting(string setting)
        {
            var node = XmlUtil.FindChildNode(setting, Configuration, false);
            return null != node ? node.InnerText : null;
        }
    }
}
