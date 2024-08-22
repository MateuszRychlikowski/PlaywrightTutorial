using AutomatedTestsConfigs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AutomatedTestsConfigs
{
    public static class ConfigManager
    {
        public static readonly AppSettings AppSettings;

        static ConfigManager()
        {
            AppSettings = GetAppSettings();
        }

        private static AppSettings GetAppSettings()
        {
            var path = File.ReadAllText("appsettings.json");
            var model = JsonConvert.DeserializeObject<AppSettings>(path);

            return model;
        }
    }
}