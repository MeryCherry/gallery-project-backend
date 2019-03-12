using System.Collections.Generic;

namespace BusinessLayer.Configuration
{
    /// <summary>
    /// Class with configurations from appsettings file
    /// </summary>
    public class AppSettingsModel
    {
        public Dictionary<string, string> ConnectionStrings { get; set; }
    }
}
