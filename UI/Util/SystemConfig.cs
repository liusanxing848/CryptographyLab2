using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu.UI.Util
{
    public class SystemConfig
    {
        public static string PATH_INPUT {  get; set; }
        public static string PATH_OUTPUT { get; set; }
        public static class NetworkConfig
        {
            public static TeamConfig TEAM_A = new TeamConfig();
            public static TeamConfig TEAM_B = new TeamConfig();
            public static TeamConfig TEAM_C = new TeamConfig();
        }
        public class TeamConfig
        {
            public string IP {  get; set; }
            public string PORT { get; set; }
            public string ENCODE { get; set; }
            public string DECODE { get; set; }
            public string SCHEMA { get; set; }
        }
    }
}
