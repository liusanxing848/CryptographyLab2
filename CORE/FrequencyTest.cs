using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu.CORE
{
    public static class FrequencyTest
    {
        public static List<KeyValuePair<char, double>> GetFrequencyResult (string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return new List<KeyValuePair<char, double>>();
            }

            
            var characterCounts = input.GroupBy(c => c)
                                       .ToDictionary(group => group.Key, group => group.Count());

            
            int totalCharacters = input.Length;

            
            var frequencyList = characterCounts.Select(kv => new KeyValuePair<char, double>(
                                                                kv.Key, Math.Round((double)kv.Value / totalCharacters, 2)))
                                               .ToList();

            
            frequencyList.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));

            return frequencyList;
        }
    }
}
