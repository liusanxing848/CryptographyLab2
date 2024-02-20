using ConsoleMenu.UI.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu.CORE
{
    public static class ProbeTool
    {
        public static string GetCyphertext(string input, string ip, string port, string encode)
        {
            string url = $"http://{ip}:{port}/{encode}{input}";

            using(HttpClient client = new HttpClient()) 
            {
                Thread.Sleep(100);
                try
                {
                    HttpResponseMessage response = client.GetAsync(url).Result;
                    response.EnsureSuccessStatusCode();
                    string resposneBody = response.Content.ReadAsStringAsync().Result;
                    return resposneBody;
                }
                catch (Exception ex) 
                { Console.WriteLine(ex);
                    return null;
                }
            }
        }

        public static void RunASCIIBrutalProbing(string ip, string port, string schema, string encode, string outputFileName)
        {
            List<string> testCases = TestCases.GenerateCharacterPatterns();
            //List<string> testCases = TestCases.MiniTestCase();
            
            var map = BruteForce.Run(testCases, ip, port, schema, encode);

            IO.DictionaryHashSetToCSVFile(SystemConfig.PATH_OUTPUT, outputFileName, map);
        }

        public static void RunDictionaryProbing_C(string ip, string port, string schema, string encode, string outputRawFileName, string outputResultFileName)
        {
            List<string> testCases = TestCases.GenerateDictionaryTestList();

            int chunkSize = 2000; // Define the size of each chunk
            int groupSize = 150; // Define the size of each group to concatenate

            // Calculate the number of chunks needed
            int numberOfChunks = (testCases.Count + chunkSize - 1) / chunkSize;

            List<string> combinedRawFiles = new List<string>();
            List<string> combinedResultFiles = new List<string>();

            for (int i = 0; i < numberOfChunks; i++)
            {
                // Get the current chunk to process
                var currentChunk = testCases.Skip(i * chunkSize).Take(chunkSize).ToList();

                // Here, concatenate every 100 strings in the chunk with spaces
                var concatenatedChunk = currentChunk
                    .Select((word, index) => new { word, index })
                    .GroupBy(x => x.index / groupSize)
                    .Select(group => string.Join(" ", group.Select(x => x.word)))
                    .ToList();

                // Process the concatenated strings
                var map = BruteForce.RunDictionaryTest_TEAMC(concatenatedChunk, ip, port, schema, encode);

                // Generate chunk-specific file names
                string currentRawFileName = $"{outputRawFileName}_part{i}.csv";
                string currentResultFileName = $"{outputResultFileName}_part{i}.csv";

                // Export chunk results to files
                IO.DictionaryTupleToCSVFile(SystemConfig.PATH_OUTPUT, currentRawFileName, map);
                IO.DictionaryTupleNonDuplicateToCSVFile(SystemConfig.PATH_OUTPUT, currentResultFileName, map);

                combinedRawFiles.Add(Path.Combine(SystemConfig.PATH_OUTPUT, currentRawFileName));
                combinedResultFiles.Add(Path.Combine(SystemConfig.PATH_OUTPUT, currentResultFileName));
            }

            // Combine all chunk files into one final file
            CombineCSVFiles(combinedRawFiles, Path.Combine(SystemConfig.PATH_OUTPUT, outputRawFileName + "_final.csv"));
            CombineCSVFiles(combinedResultFiles, Path.Combine(SystemConfig.PATH_OUTPUT, outputResultFileName + "_final.csv"));
        }

        public static void RunDictionaryProbing_B(string ip, string port, string schema, string encode, string outputRawFileName, string outputResultFileName)
        {
            List<string> testCases = TestCases.GenerateDictionaryTestList();

            int chunkSize = 2000; // Define the size of each chunk
            int groupSize = 150; // Define the size of each group to concatenate

            // Calculate the number of chunks needed
            int numberOfChunks = (testCases.Count + chunkSize - 1) / chunkSize;

            List<string> combinedRawFiles = new List<string>();
            List<string> combinedResultFiles = new List<string>();

            for (int i = 0; i < numberOfChunks; i++)
            {
                // Get the current chunk to process
                var currentChunk = testCases.Skip(i * chunkSize).Take(chunkSize).ToList();

                // Here, concatenate every 100 strings in the chunk with spaces
                var concatenatedChunk = currentChunk
                    .Select((word, index) => new { word, index })
                    .GroupBy(x => x.index / groupSize)
                    .Select(group => string.Join(" ", group.Select(x => x.word)))
                    .ToList();

                // Process the concatenated strings
                var map = BruteForce.RunDictionaryTest_TEAMB(concatenatedChunk, ip, port, schema, encode);

                // Generate chunk-specific file names
                string currentRawFileName = $"{outputRawFileName}_part{i}.csv";
                string currentResultFileName = $"{outputResultFileName}_part{i}.csv";

                // Export chunk results to files
                IO.DictionaryTupleToCSVFile(SystemConfig.PATH_OUTPUT, currentRawFileName, map);
                IO.DictionaryTupleNonDuplicateToCSVFile(SystemConfig.PATH_OUTPUT, currentResultFileName, map);

                combinedRawFiles.Add(Path.Combine(SystemConfig.PATH_OUTPUT, currentRawFileName));
                combinedResultFiles.Add(Path.Combine(SystemConfig.PATH_OUTPUT, currentResultFileName));
            }

            // Combine all chunk files into one final file
            CombineCSVFiles(combinedRawFiles, Path.Combine(SystemConfig.PATH_OUTPUT, outputRawFileName + "_final.csv"));
            CombineCSVFiles(combinedResultFiles, Path.Combine(SystemConfig.PATH_OUTPUT, outputResultFileName + "_final.csv"));
        }

        private static void CombineCSVFiles(List<string> inputFiles, string outputFile)
        {
            using (var writer = new StreamWriter(outputFile))
            {
                foreach (var file in inputFiles)
                {
                    using (var reader = new StreamReader(file))
                    {
                        while (!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();
                            writer.WriteLine(line);
                        }
                    }

                    // Optional: Delete the part files after combining
                    File.Delete(file);
                }
            }
        }
    }
}
