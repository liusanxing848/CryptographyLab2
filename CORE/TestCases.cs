using ConsoleMenu.UI.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu.CORE
{
    internal static class TestCases
    {
        public static List<string> MiniTestCase()
        {
            List<string> list = new List<string>();
            list.Add("a");
            list.Add(" \"\" ");
            list.Add("a");
            list.Add("a");
            list.Add("@");
            list.Add("#");
            list.Add("(");
            list.Add("a");
            list.Add("a");
            list.Add("aa");
            list.Add("b");
            list.Add("bb");
            list.Add("ab");
            list.Add("aabb");
            list.Add("abab");
            return list;
        }
        public static List<string> GenerateCharacterPatterns()
        {
            List<string> patterns = new List<string>();
            // First ASCII range
            for (int ascii = 48; ascii <= 57; ascii++)
            {
                _AddPatternsForChar(patterns, ascii);
            }
            // Second ASCII range
            for (int ascii = 97; ascii <= 122; ascii++)
            {
                _AddPatternsForChar(patterns, ascii);
            }
            return patterns;
        }

        private static void _AddPatternsForChar(List<string> patterns, int ascii)
        {
            char character = (char)ascii;
            for (int length = 1; length <= 5; length++)
            {
                string pattern = new string(character, length);
                // Repeat each pattern 5 times
                for (int repeat = 0; repeat < 5; repeat++)
                {
                    patterns.Add(pattern);
                }
            }
        }

        public static List<string> GenerateDictionaryTestList()
        {
            List<string> testList = IO.ReadDictionaryTestFile();
            Console.WriteLine("Length: " + testList.Count);

            return testList;
        }
    }
}
