using ConsoleMenu.CORE;
using ConsoleMenu.UI.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu.UI
{
    public static class Menu
    {
        public static string[] options = new string[]
        {
            "Display Configuration", //1
            "Load Configuration", //2
            "Run ASCII Brute Force for Team B",//3
            "Run ASCII Brute Force for Team C",//4
            "Run Frequency Test for Team B", //5
            "Run Frequency Test for Team C", //6
            "Run Dictionary for Team B", //7
            "Run Dictionay for Team C", //8
            "Test Team B code book", //9
            "Test Team C code book", //10
            "Exit"
        };

        public static void Run()
        {
            Layout page = new Layout(options, _prompt);
            int currentSelection = page.RunMenu();
            switch (currentSelection)
            {
                case 0:
                    Console.Clear();
                    Run();
                    break;
                case 1:
                    _ViewDefaultConfigs();
                    break;
                case 2:
                    _LoadConfigurations();
                    break;
                case 3:
                    _BruteASCIITeamB();
                    break;
                case 4:
                    _BruteASCIITeamC();
                    break;
                case 5:
                    Console.Clear();
                    Run();
                    break;
                case 6:
                    Console.Clear();
                    Run();
                    break;
                case 7:
                    Console.Clear();
                    _RunDictionayforTeamB();
                    break;
                case 8:
                    Console.Clear();
                    _RunDictionayforTeamC();
                    break;
                case 9:
                    Console.Clear();
                    Run();
                    break;
                case 10:
                    Console.Clear();
                    Run();
                    break;
                default:
                    break;
            }
        }

        private static void _FileExplorer()
        {
            Console.Clear();
            string selectedFilePath = " ";
            FileExporer.Run(out selectedFilePath, Run, Run);
        }

        private static void _ViewDefaultConfigs()
        {
            Console.Clear();
            DisplayPage.Run(Menu.Run, IO.ReadYAMLtoString("", "systemConfig.yaml"));
        }

        private static void _LoadConfigurations()
        {
            Console.Clear();
            IO.SystemConfigurationInitialization();
            App.ConsoleWriteGreen("Configuration loaded!");
            //DisplayPage.Run(Menu.Run, IO.ReadYAMLtoString("", "systemConfig.yaml"));

            Console.WriteLine(SystemConfig.NetworkConfig.TEAM_C.IP);
            Console.WriteLine(SystemConfig.NetworkConfig.TEAM_C.PORT);
            Console.WriteLine(SystemConfig.NetworkConfig.TEAM_C.SCHEMA);
            Console.WriteLine(SystemConfig.NetworkConfig.TEAM_C.ENCODE);
            Console.ReadKey();
            Console.Clear();
            Menu.Run();
        }

        private static void _BruteASCIITeamB()
        {
            ProbeTool.RunASCIIBrutalProbing(SystemConfig.NetworkConfig.TEAM_B.IP,
                                            SystemConfig.NetworkConfig.TEAM_B.PORT,
                                            SystemConfig.NetworkConfig.TEAM_B.SCHEMA,
                                            SystemConfig.NetworkConfig.TEAM_B.ENCODE,
                                            "BruteASCIITeamB.csv");
        }

        private static void _BruteASCIITeamC()
        {
            Console.Clear();
            ProbeTool.RunASCIIBrutalProbing(SystemConfig.NetworkConfig.TEAM_C.IP,
                                            SystemConfig.NetworkConfig.TEAM_C.PORT,
                                            SystemConfig.NetworkConfig.TEAM_C.SCHEMA,
                                            SystemConfig.NetworkConfig.TEAM_C.ENCODE,
                                            "BruteASCIITeamC.csv");
            Console.ReadKey();
            Console.Clear();
            Menu.Run();
        }
        
        private static void _RunDictionayforTeamC()
        {
            Console.Clear();
            ProbeTool.RunDictionaryProbing_C(SystemConfig.NetworkConfig.TEAM_C.IP,
                                           SystemConfig.NetworkConfig.TEAM_C.PORT,
                                           SystemConfig.NetworkConfig.TEAM_C.SCHEMA,
                                           SystemConfig.NetworkConfig.TEAM_C.ENCODE,
                                           "adj,v,adv_C.csv",
                                           "ReservedWordadj,v,adv_C.csv");
        }

        private static void _RunDictionayforTeamB()
        {
            Console.Clear();
            ProbeTool.RunDictionaryProbing_B(SystemConfig.NetworkConfig.TEAM_B.IP,
                                           SystemConfig.NetworkConfig.TEAM_B.PORT,
                                           SystemConfig.NetworkConfig.TEAM_B.SCHEMA,
                                           SystemConfig.NetworkConfig.TEAM_B.ENCODE,
                                           "nouns91K_B.csv",
                                           "ReservedWordResultnouns91K_B.csv");
        }






        //https://www.asciiart.eu/text-to-ascii-art
        private static string _prompt = @"         
 _        _    ____    ____    _____ _____    _    __  __      _    
| |      / \  | __ )  |___ \  |_   _| ____|  / \  |  \/  |    / \   
| |     / _ \ |  _ \    __) |   | | |  _|   / _ \ | |\/| |   / _ \  
| |___ / ___ \| |_) |  / __/    | | | |___ / ___ \| |  | |  / ___ \ 
|_____/_/   \_\____/  |_____|   |_| |_____/_/   \_\_|  |_| /_/   \_\
";
    }
}
