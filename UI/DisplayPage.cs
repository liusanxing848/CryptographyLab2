using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu.UI
{
    internal class DisplayPage
    {
        private static string[] _options = new string[] { "" };

        public static void Run(Action pageOption, string displayContent)
        {
            Layout menu = new Layout(_options, displayContent);
            int curr = menu.RunMenu();
            try
            {
                switch (curr)
                {
                    case 0:
                        Console.Clear();
                        try
                        {
                            pageOption.Invoke();
                        }
                        catch (Exception ex)
                        {
                            Console.Clear();
                            pageOption.Invoke();
                        }
                        break;
                    case 1:
                        Console.Clear();
                        pageOption.Invoke();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.Clear();
                pageOption.Invoke();
            }

        }
    }
}
