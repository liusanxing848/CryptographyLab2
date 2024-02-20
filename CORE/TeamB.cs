using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu.CORE
{
    internal static class TeamB
    {
        public static Dictionary<char, char> map;

        static TeamB()
        {
            map = new Dictionary<char, char>();
            map.Add('a', 'l');
            map.Add('b', 'm');
            map.Add('c', 'n');
            map.Add('d', 'o');
            map.Add('e', 'p');
            map.Add('f', 'q');
            map.Add('g', 'r');
            map.Add('h', 's');
            map.Add('i', 't');
            map.Add('j', 'u');
            map.Add('k', 'v');
            map.Add('l', 'w');
            map.Add('m', 'x');
            map.Add('n', 'y');
            map.Add('o', 'z');
            map.Add('p', 'a');
            map.Add('q', 'b');
            map.Add('r', 'c');
            map.Add('s', 'd');
            map.Add('t', 'e');
            map.Add('u', 'f');
            map.Add('v', 'g');
            map.Add('w', 'h');
            map.Add('x', 'i');
            map.Add('y', 'j');
            map.Add('z', 'k');
        }

        public static string Encode(string input)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (char c in input) 
            {
                if(map.ContainsKey(c))
                {
                    stringBuilder.Append(map[c]);
                }
            }
            return stringBuilder.ToString();
        }
    }
}
