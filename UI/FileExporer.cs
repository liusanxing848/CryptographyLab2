using ConsoleMenu.UI.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu.UI
{
    internal class FileExporer
    {
        private static string[] _options;
        private static string _prompt = "Please select file";

        public static void Run(out string selectedFilePath, Action ForwardPageOption = null, Action BackwardPageOption = null)
        {
            List<string> opts = IO.FileToMenuOption(GLOBAL.PATH.INPUT_FOLDER);
            _options = new string[opts.Count];
            _options = opts.ToArray();
            Layout menu = new Layout(_options, _prompt);
            int curr = menu.RunMenu();
            if (curr == 0)
            {
                Console.Clear();
                Run(out selectedFilePath, ForwardPageOption, BackwardPageOption);
            }
            if (curr == _options.Length)
            {
                Console.Clear();
                BackwardPageOption.Invoke();
                selectedFilePath = null;
            }
            else
            {
                Console.Clear();
                selectedFilePath = "" + _options[curr - 1];
                ForwardPageOption.Invoke();
            }
        }
    }
}
