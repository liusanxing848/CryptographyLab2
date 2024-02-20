using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu.CORE
{
    internal class TeamC
    {
        public static Dictionary<char, Tuple<char, char>> map;

        static TeamC()
        {
            map = new Dictionary<char, Tuple<char, char>>();

            map.Add('a', Tuple.Create('x', 'd'));
            map.Add('b', Tuple.Create('y', 'e'));
            map.Add('c', Tuple.Create('z', 'f'));
            map.Add('d', Tuple.Create('a', 'g'));
            map.Add('e', Tuple.Create('b', 'h'));
            map.Add('f', Tuple.Create('c', 'i'));
            map.Add('g', Tuple.Create('d', 'j'));
            map.Add('h', Tuple.Create('e', 'k'));
            map.Add('i', Tuple.Create('f', 'l'));
            map.Add('j', Tuple.Create('g', 'm'));
            map.Add('k', Tuple.Create('h', 'n'));
            map.Add('l', Tuple.Create('i', 'o'));
            map.Add('m', Tuple.Create('j', 'p'));
            map.Add('n', Tuple.Create('k', 'q'));
            map.Add('o', Tuple.Create('l', 'r'));
            map.Add('p', Tuple.Create('m', 's'));
            map.Add('q', Tuple.Create('n', 't'));
            map.Add('r', Tuple.Create('o', 'u'));
            map.Add('s', Tuple.Create('p', 'v'));
            map.Add('t', Tuple.Create('q', 'w'));
            map.Add('u', Tuple.Create('r', 'x'));
            map.Add('v', Tuple.Create('s', 'y'));
            map.Add('w', Tuple.Create('t', 'z'));
            map.Add('x', Tuple.Create('u', 'a'));
            map.Add('y', Tuple.Create('v', 'b'));
            map.Add('z', Tuple.Create('w', 'c'));

            map.Add('1', Tuple.Create('8', '4'));
            map.Add('2', Tuple.Create('9', '5'));
            map.Add('3', Tuple.Create('0', '6'));
            map.Add('4', Tuple.Create('1', '7'));
            map.Add('5', Tuple.Create('2', '8'));
            map.Add('6', Tuple.Create('3', '9'));
            map.Add('7', Tuple.Create('4', '0'));
            map.Add('8', Tuple.Create('5', '1'));
            map.Add('9', Tuple.Create('6', '2'));
            map.Add('0', Tuple.Create('7', '3'));

            map.Add(' ', Tuple.Create(' ', ' '));
        }

        public static string Encode(string input)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                if (map.ContainsKey(input[i]))
                {
                    if (i % 2 == 0)
                    {
                        stringBuilder.Append(map[input[i]].Item1);
                    }
                    else
                    {
                        stringBuilder.Append(map[input[i]].Item2);
                    }
                }
            }
            return stringBuilder.ToString();
        }
    }
}
