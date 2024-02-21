using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Core.Tokens;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace ConsoleMenu.UI.Util
{
    internal static class IO
    {
        public static string ReadYAMLtoString(string path, string filename)
        {
            
            string yaml = File.ReadAllText(path + filename);

            return yaml;
        }

        public static void SystemConfigurationInitialization()
        {
            string sysConfigPath = "systemConfig.yaml";
            string yaml = File.ReadAllText(sysConfigPath);
            
            IDeserializer deserializer = new DeserializerBuilder().WithNamingConvention(CamelCaseNamingConvention.Instance).Build();
            var configObj = deserializer.Deserialize<dynamic>(yaml);
            
            SystemConfig.PATH_INPUT = configObj["system"]["input"];
            SystemConfig.PATH_OUTPUT = configObj["system"]["output"];

            SystemConfig.NetworkConfig.TEAM_A.IP = configObj["network"]["teamA"]["ip"];
            SystemConfig.NetworkConfig.TEAM_A.PORT = configObj["network"]["teamA"]["port"];
            SystemConfig.NetworkConfig.TEAM_A.ENCODE = configObj["network"]["teamA"]["encode"];
            SystemConfig.NetworkConfig.TEAM_A.DECODE = configObj["network"]["teamA"]["decode"];
            SystemConfig.NetworkConfig.TEAM_A.SCHEMA = configObj["network"]["teamA"]["schema"];

            SystemConfig.NetworkConfig.TEAM_B.IP = configObj["network"]["teamB"]["ip"];
            SystemConfig.NetworkConfig.TEAM_B.PORT = configObj["network"]["teamB"]["port"];
            SystemConfig.NetworkConfig.TEAM_B.ENCODE = configObj["network"]["teamB"]["encode"];
            SystemConfig.NetworkConfig.TEAM_B.DECODE = configObj["network"]["teamB"]["decode"];
            SystemConfig.NetworkConfig.TEAM_B.SCHEMA = configObj["network"]["teamB"]["schema"];

            SystemConfig.NetworkConfig.TEAM_C.IP = configObj["network"]["teamC"]["ip"];
            SystemConfig.NetworkConfig.TEAM_C.PORT = configObj["network"]["teamC"]["port"];
            SystemConfig.NetworkConfig.TEAM_C.ENCODE = configObj["network"]["teamC"]["encode"];
            SystemConfig.NetworkConfig.TEAM_C.DECODE = configObj["network"]["teamC"]["decode"];
            SystemConfig.NetworkConfig.TEAM_C.SCHEMA = configObj["network"]["teamC"]["schema"];

        }
        public static List<string> FileToMenuOption(string filePath)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(filePath);
            FileInfo[] fileInfos = dirInfo.GetFiles("*");

            List<string> menuOptions = new List<string>();
            foreach (FileInfo fInfo in fileInfos)
            {
                menuOptions.Add(fInfo.Name);
            }
            menuOptions.Add("BACK");

            return menuOptions;
        }

        public static void DictionaryHashSetToCSVFile(string outputPath, string fileName, Dictionary<string, HashSet<string>> map)
        {
            StreamWriter writer = new StreamWriter(outputPath + fileName, false);
            foreach (KeyValuePair<string, HashSet<string>> kvp in map)
            {
                StringBuilder sb = new StringBuilder(kvp.Key);
                foreach(string value in kvp.Value)
                {
                    sb.Append($",{value}");
                }
                writer.WriteLine(sb.ToString());
            }
            writer.Close();
        }

        public static void DictionaryTupleToCSVFile(string outputPath, string fileName, Dictionary<string, Tuple<string, string>> map)
        {
            StreamWriter writer = new StreamWriter(outputPath + fileName, false);
            foreach (KeyValuePair<string, Tuple<string, string>> kvp in map)
            {
                StringBuilder sb = new StringBuilder(kvp.Key);
                sb.Append($",{kvp.Value.Item1}");
                sb.Append($",{kvp.Value.Item2}");
                writer.WriteLine(sb.ToString());
            }
            writer.Close();
        }

        public static void DictionaryTupleNonDuplicateToCSVFile(string outputPath, string fileName, Dictionary<string, Tuple<string, string>> map)
        {
            StreamWriter writer = new StreamWriter(outputPath + fileName, false);
            foreach (KeyValuePair<string, Tuple<string, string>> kvp in map)
            {
                if(kvp.Value.Item1 != kvp.Value.Item2)
                {
                    StringBuilder sb = new StringBuilder(kvp.Key);
                    sb.Append($",{kvp.Value.Item1}");
                    sb.Append($",{kvp.Value.Item2}");
                    writer.WriteLine(sb.ToString());
                    App.ConsoleWriteRed("Found Reserved word: " + sb.ToString());
                }
            }
            writer.Close();
        }

        public static void DictionaryPairStringToCSVFile(string outputPathAndFileName, Dictionary<string, string> map)
        {
            StreamWriter writer = new StreamWriter(outputPathAndFileName, true);
            foreach(KeyValuePair<string, string> kvp in map) 
            {
                StringBuilder sb = new StringBuilder(kvp.Key);
                sb.Append($",{kvp.Value}");
            }
            writer.Close();
        }
        

        public static List<string> ReadDictionaryTestFile()
        {
            string filePath = "input/cities.txt";
            return File.ReadAllLines(filePath).ToList();
        }
    }
}
