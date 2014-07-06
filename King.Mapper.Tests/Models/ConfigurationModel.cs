using System.Configuration;

namespace King.Mapper.Tests.Models
{
    public class ConfigurationModel
    {
        public string Database
        {
            get;
            set;
        }
        public int SiteId
        {
            get;
            set;
        }
        public string ApiUrl
        {
            get;
            set;
        }

        public static ConfigurationModel Load()
        {
            return ConfigurationManager.AppSettings.Map<ConfigurationModel>();
        }
    }
}
