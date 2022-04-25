using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebPageV2.Data.Models.Settings
{
    public class DatabaseSettings
    {
        public const string DatabaseSection = "Database";
        public string? ConnectionString { get; set; }
    }
}
