using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu.CORE
{
    public static class BruteForce
    {
        public static Dictionary<string, HashSet<string>> Run(List<string> list, string ip, string port, string schema, string encode) 
        {
            Dictionary<string, HashSet<string>> map = new Dictionary<string, HashSet<string>>();
            foreach (string s in list) 
            {
                string resp = ProbeTool.GetCyphertext(s, ip, port, encode);
                Console.WriteLine(resp);
                var jsonObject = JObject.Parse(resp);
                string res = jsonObject[schema]!.ToString();
                Console.WriteLine("Parsed: " + res);
                if (!map.ContainsKey(s))
                {
                    map[s] = new HashSet<string>();
                    map[s].Add(res);
                }
                else
                {
                    map[s].Add(res);
                }
            }
            foreach (KeyValuePair<string, HashSet<string>> kvp in map) 
            {
                Console.Write(kvp.Key + ": ");
                foreach (string s in kvp.Value) 
                {
                    Console.Write(s + ",");
                }
            }
            return map;
        }

        public static Dictionary<string, Tuple<string, string>> RunDictionaryTest_TEAMC(List<string> list, string ip, string port, string schema, string encode)
        {
            Dictionary<string, Tuple<string, string>> map = new Dictionary<string, Tuple<string, string>>();

            foreach (string s in list)
            {
                string resp = ProbeTool.GetCyphertext(s, ip, port, encode);
                Console.WriteLine(resp);
                var jsonObject = JObject.Parse(resp);
                string res = jsonObject[schema]!.ToString();
                Console.Write("Parsed: " + res + "    ");
                string anticipate = TeamC.Encode(s);
                Console.WriteLine("Anticipated: " + anticipate);
                if(!map.ContainsKey(s))
                {
                    map.Add(s, Tuple.Create(res, anticipate));
                }
            }
            return map;
        }

        public static Dictionary<string, Tuple<string, string>> RunDictionaryTest_TEAMB(List<string> list, string ip, string port, string schema, string encode)
        {
            Dictionary<string, Tuple<string, string>> map = new Dictionary<string, Tuple<string, string>>();

            foreach (string s in list)
            {
                string resp = ProbeTool.GetCyphertext(s, ip, port, encode);
                Console.WriteLine(resp);
                var jsonObject = JObject.Parse(resp);
                string res = jsonObject[schema]!.ToString();
                Console.Write("Parsed: " + res + "    ");
                string anticipate = TeamB.Encode(s);
                Console.WriteLine("Anticipated: " + anticipate);
                if (!map.ContainsKey(s))
                {
                    map.Add(s, Tuple.Create(res, anticipate));
                }
            }
            return map;
        }
    }
}
