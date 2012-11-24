using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Windesheim.Social.Common.Extensions;

namespace Windesheim.Social.Common
{
    public static class ConfigHelper
    {
        public static object Read<T>(string settingName)
        {
            var setting = ConfigurationManager.AppSettings[settingName];
            if (setting.IsNullOrEmpty())
                throw new ConfigurationException("Configsetting {0} isn't filled out".FormatWith(settingName));

            var type = typeof(T);
            switch (type.Name.ToLower())
            {
                case "string":
                    return setting;
                default:
                    throw new InvalidOperationException("Type {0} cannot be parsed".FormatWith(type));
            }
        }
    }
}
